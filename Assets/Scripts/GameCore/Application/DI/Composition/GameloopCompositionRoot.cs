using GameCore.Gameplay.Common.Collisions;
using GameCore.Gameplay.Features.InputFeature.Systems;
using GameCore.Gameplay.Features.MovingFeature.Systems;
using GameCore.Gameplay.Features.PlayerFeature;
using GameCore.Gameplay.Features.Views.Factory;
using GameCore.Gameplay.Features.Views.Systems;
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

            containerBuilder.Register<PlayerInitSystem>(Lifetime.Singleton);
            containerBuilder.Register<MoveSystem>(Lifetime.Singleton);
            containerBuilder.Register<InputSystem>(Lifetime.Singleton);
            containerBuilder.Register<InputToMoveSystem>(Lifetime.Singleton);
            containerBuilder.Register<CleanupInputSystem>(Lifetime.Singleton);
            containerBuilder.Register<BindEntityViewFromPathSystem>(Lifetime.Singleton);
            containerBuilder.Register<BindEntityViewFromPrefabSystem>(Lifetime.Singleton);
        }

        public override void OnResolve(IObjectResolver sceneResolver)
        {
            _world = World.Create();
            _world.UpdateByUnity = true;

            var systemsGroup = _world.CreateSystemsGroup();

            systemsGroup.AddInitializer(sceneResolver.Resolve<PlayerInitSystem>());

            systemsGroup.AddSystem(sceneResolver.Resolve<BindEntityViewFromPathSystem>());
            systemsGroup.AddSystem(sceneResolver.Resolve<BindEntityViewFromPrefabSystem>());

            systemsGroup.AddSystem(sceneResolver.Resolve<InputSystem>());

            systemsGroup.AddSystem(sceneResolver.Resolve<InputToMoveSystem>());

            systemsGroup.AddSystem(sceneResolver.Resolve<MoveSystem>());

            systemsGroup.AddSystem(sceneResolver.Resolve<CleanupInputSystem>());

            _world.AddSystemsGroup(order: 0, systemsGroup);
        }

        private void OnDestroy()
        {
            _world?.Dispose();
        }
    }
}