using Cysharp.Threading.Tasks;
using UnityEngine;

namespace GameCore.Infrastructure.Abstraction.AssetManagement
{
    public interface IResourceService
    {
        UniTask<T> LoadAsync<T>(string assetKey) where T : class;
        UniTask<T> CreateAsync<T>(string assetKey) where T : Object;
    }
}