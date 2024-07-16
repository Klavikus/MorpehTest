using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Modules.Infrastructure.Implementation
{
    public abstract class SceneCompositionRoot : MonoBehaviour
    {
        public UniTask Initialize(IObjectResolver objectResolver)
        {
            IScopedObjectResolver sceneResolver = objectResolver.CreateScope(OnRegister);
            OnResolve(sceneResolver);

            return default;
        }

        public abstract void OnRegister(IContainerBuilder containerBuilder);

        public abstract void OnResolve(IObjectResolver sceneResolver);
    }
}