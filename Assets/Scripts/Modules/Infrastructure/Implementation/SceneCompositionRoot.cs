using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace Modules.Infrastructure.Implementation
{
    public abstract class SceneCompositionRoot : MonoBehaviour
    {
        private IScopedObjectResolver _sceneResolver;

        public UniTask Initialize(IObjectResolver objectResolver)
        {
            _sceneResolver = objectResolver.CreateScope(OnRegister);
            OnResolve(_sceneResolver);

            return default;
        }

        public abstract void OnRegister(IContainerBuilder containerBuilder);

        public abstract void OnResolve(IObjectResolver sceneResolver);

        private void OnDestroy() =>
            _sceneResolver?.Dispose();
    }
}