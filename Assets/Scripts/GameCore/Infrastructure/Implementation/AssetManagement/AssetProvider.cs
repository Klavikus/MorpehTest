using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameCore.Infrastructure.Abstraction.AssetManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace GameCore.Infrastructure.Implementation.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> assetRequests = new();

        public async UniTask InitializeAsync() =>
            await Addressables.InitializeAsync().ToUniTask();

        public async UniTask<TAsset> Load<TAsset>(string key)
            where TAsset : class
        {
            if (!assetRequests.TryGetValue(key, out AsyncOperationHandle handle))
            {
                handle = Addressables.LoadAssetAsync<TAsset>(key);
                assetRequests.Add(key, handle);
            }

            await handle.ToUniTask();

            return handle.Result as TAsset;
        }

        public async UniTask<TAsset> Load<TAsset>(AssetReference assetReference)
            where TAsset : class =>
            await Load<TAsset>(assetReference.AssetGUID);

        public async UniTask<List<string>> GetAssetsListByLabel<TAsset>(string label) =>
            await GetAssetsListByLabel(label, typeof(TAsset));

        public async UniTask<List<string>> GetAssetsListByLabel(string label, Type type = null)
        {
            var operationHandle = Addressables.LoadResourceLocationsAsync(label, type);

            var locations = await operationHandle.ToUniTask();

            List<string> assetKeys = new List<string>(locations.Count);

            foreach (var location in locations)
                assetKeys.Add(location.PrimaryKey);

            Addressables.Release(operationHandle);

            return assetKeys;
        }

        public async UniTask<TAsset[]> LoadAll<TAsset>(List<string> keys) where TAsset : class
        {
            List<UniTask<TAsset>> tasks = new List<UniTask<TAsset>>(keys.Count);

            foreach (var key in keys)
                tasks.Add(Load<TAsset>(key));

            return await UniTask.WhenAll(tasks);
        }

        public async UniTask WarmupAssetsByLabel(string label)
        {
            var assetsList = await GetAssetsListByLabel(label);
            await LoadAll<object>(assetsList);
        }

        public async UniTask ReleaseAssetsByLabel(string label)
        {
            var assetsList = await GetAssetsListByLabel(label);

            foreach (var assetKey in assetsList)
            {
                if (assetRequests.TryGetValue(assetKey, out var handler))
                {
                    Addressables.Release(handler);
                    assetRequests.Remove(assetKey);
                }
            }
        }

        public void Cleanup()
        {
            foreach (var assetRequest in assetRequests)
                Addressables.Release(assetRequest.Value);

            assetRequests.Clear();
        }

        private async UniTask<long> GetAssetSizeAsync(string key)
        {
            // Здесь получаем размер для загрузки
            long downloadSize = await Addressables.GetDownloadSizeAsync(key).Task;

            Debug.Log(downloadSize > 0
                ? $"{nameof(AssetProvider)}: Download size for asset {key} is {downloadSize} bytes."
                : $"{nameof(AssetProvider)}: No download needed for asset {key}, it might be already cached.");

            return downloadSize;
        }

        public async UniTask<List<IResourceLocation>> GetAssetDependencies(string reference)
        {
            // Получаем список местоположений ресурсов
            var locationsHandle = Addressables.LoadResourceLocationsAsync(reference, typeof(UnityEngine.Object));
            await locationsHandle.Task; // Асинхронно ожидаем загрузки местоположений

            List<IResourceLocation> locations = locationsHandle.Result.ToList();

            // Теперь мы можем перебрать список locations, чтобы увидеть все зависимости
            foreach (var location in locations)
            {
                Debug.Log($"Asset location: {location.PrimaryKey}"); // PrimaryKey отображает ключ ассета или его адрес
            }

            // Не забудьте освободить дескриптор
            Addressables.Release(locationsHandle);

            return locations;
        }
    }
}