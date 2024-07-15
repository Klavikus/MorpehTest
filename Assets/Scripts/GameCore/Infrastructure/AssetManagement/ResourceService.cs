using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameCore.Infrastructure.AssetManagement
{
    public class ResourceService : IResourceService
    {
        private readonly Dictionary<Type, Func<string, UniTask<object>>> _loaders;

        public ResourceService(IAssetProvider assetProvider)
        {
            _loaders = new Dictionary<Type, Func<string, UniTask<object>>>()
            {
                {typeof(ScriptableObject), async (key) => await assetProvider.Load<ScriptableObject>(key)},
                {typeof(GameObject), async (key) => await assetProvider.Load<GameObject>(key)},
                {typeof(AudioClip), async (key) => await assetProvider.Load<AudioClip>(key)},
                {typeof(ConfigurationContainer), async (key) => await assetProvider.Load<ScriptableObject>(key)},
            };
        }

        public async UniTask<T> LoadAsync<T>(string assetKey)
            where T : class
        {
            if (_loaders.TryGetValue(typeof(T), out var loader))
                return await loader(assetKey) as T;

            throw new Exception($"Can't LoadAsync asset of type:{typeof(T)} with key:{assetKey}");
        }

        public async UniTask<T> CreateAsync<T>(string assetKey)
            where T : Object
        {
            GameObject loaded = await LoadAsync<GameObject>(assetKey);

            return Object.Instantiate(loaded.GetComponent<T>());
        }
    }
}