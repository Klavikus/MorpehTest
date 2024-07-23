using GameCore.Gameplay.Common.Collisions;
using GameCore.Gameplay.Features.AnimationFeature;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.InputFeature;
using GameCore.Gameplay.Features.MovingFeature;
using GameCore.Gameplay.Features.PlayerFeature;
using GameCore.Gameplay.Features.ViewFeature;
using GameCore.Gameplay.Features.ViewFeature.Factory;
using GameCore.Gameplay.Services;
using Modules.Infrastructure.Implementation;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameCore.Application.DI.Composition
{
    public class GameloopCompositionRoot : SceneCompositionRoot
    {
        [SerializeField] private GameplayCamera _gameplayCamera;

        private World _world;

        public override void OnRegister(IContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterComponent(_gameplayCamera);

            containerBuilder.Register<ICollisionRegistry, CollisionRegistry>(Lifetime.Singleton);
            containerBuilder.Register<IEntityViewFactory, EntityViewFactory>(Lifetime.Singleton);
        }

        public override void OnResolve(IObjectResolver sceneResolver)
        {
            _world = World.Create();
            _world.UpdateByUnity = true;

            _world.AddFeature<ViewFeature>(sceneResolver);
            _world.AddFeature<InputFeature>(sceneResolver);
            _world.AddFeature<PlayerFeature>(sceneResolver);
            _world.AddFeature<MoveFeature>(sceneResolver);
            _world.AddFeature<AnimationFeature>(sceneResolver);
        }

        private void OnDestroy()
        {
            _world?.Dispose();
        }
    }
}