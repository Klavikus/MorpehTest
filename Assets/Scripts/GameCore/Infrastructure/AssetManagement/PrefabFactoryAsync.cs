using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameCore.Infrastructure.AssetManagement
{
    public class PrefabFactoryAsync<TComponent>
        where TComponent : Object
    {
        private readonly IAssetProvider _assetProvider;

        public PrefabFactoryAsync(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async UniTask<TComponent> Create(string assetKey)
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(assetKey);
            TComponent newObject = Object.Instantiate(prefab).GetComponent<TComponent>();

            return newObject;
        }
    }
}