using UnityEngine;
using VContainer;

namespace Modules.Infrastructure.Implementation
{
    public abstract class SceneCompositionRoot : MonoBehaviour
    {
        public void Initialize(IObjectResolver objectResolver)
        {
            IScopedObjectResolver sceneResolver = objectResolver.CreateScope(OnRegister);
            OnResolve(sceneResolver);
        }

        public abstract void OnRegister(IContainerBuilder containerBuilder);

        public abstract void OnResolve(IObjectResolver sceneResolver);
    }
}