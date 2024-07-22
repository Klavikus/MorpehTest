using System;
using Code.Infrastructure.Systems;
using GameCore.Gameplay.Common.Collisions;
using GameCore.Gameplay.Features;
using GameCore.Gameplay.Features.AnimationFeature;
using GameCore.Gameplay.Features.AnimationFeature.Systems;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.InputFeature;
using GameCore.Gameplay.Features.InputFeature.Systems;
using GameCore.Gameplay.Features.MovingFeature;
using GameCore.Gameplay.Features.MovingFeature.Systems;
using GameCore.Gameplay.Features.PlayerFeature;
using GameCore.Gameplay.Features.PlayerFeature.Systems;
using GameCore.Gameplay.Features.ViewFeature;
using GameCore.Gameplay.Features.ViewFeature.Factory;
using GameCore.Gameplay.Features.ViewFeature.Systems;
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
            containerBuilder.Register<ISystemFactory, SystemFactory>(Lifetime.Singleton);

            containerBuilder.Register<PlayerInitSystem>(Lifetime.Singleton);
            containerBuilder.Register<MoveSystem>(Lifetime.Singleton);
            containerBuilder.Register<InputSystem>(Lifetime.Singleton);
            containerBuilder.Register<InputToMoveSystem>(Lifetime.Singleton);
            containerBuilder.Register<CleanupInputSystem>(Lifetime.Singleton);
            containerBuilder.Register<BindEntityViewFromPathSystem>(Lifetime.Singleton);
            containerBuilder.Register<BindEntityViewFromPrefabSystem>(Lifetime.Singleton);
            containerBuilder.Register<AnimatorSynchronizationSystem>(Lifetime.Singleton);
            containerBuilder.Register<ChangeAnimationProcessSystem>(Lifetime.Singleton);

            containerBuilder.Register<ViewFeature>(Lifetime.Singleton);
            containerBuilder.Register<InputFeature>(Lifetime.Singleton);
            containerBuilder.Register<PlayerFeature>(Lifetime.Singleton);
            containerBuilder.Register<MoveFeature>(Lifetime.Singleton);
            containerBuilder.Register<AnimationFeature>(Lifetime.Singleton);
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