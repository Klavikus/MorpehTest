using Code.Common;
using GameCore.Controllers.Presenters.Gameplay;
using GameCore.Domain.Configs;
using GameCore.Extensions;
using GameCore.Gameplay.Common;
using GameCore.Gameplay.Common.Collisions;
using GameCore.Gameplay.Features.AnimationFeature;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.Cooldowns;
using GameCore.Gameplay.Features.InputFeature;
using GameCore.Gameplay.Features.MovingFeature;
using GameCore.Gameplay.Features.PlayerFeature;
using GameCore.Gameplay.Features.PlayerFeature.Factories;
using GameCore.Gameplay.Features.StatsApplierFeature;
using GameCore.Gameplay.Features.UnitFeature;
using GameCore.Gameplay.Features.UnitFeature.Factories;
using GameCore.Gameplay.Features.ViewFeature;
using GameCore.Gameplay.Features.ViewFeature.Factory;
using GameCore.Presentation.Implementation.Gameplay;
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
        [SerializeField] private GameplaySceneConfig _gameplaySceneConfig;
        [SerializeField] private GameplayMainView _gameplayMainView;

        private World _world;

        public override void OnRegister(IContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterComponent(_gameplayCamera);
            containerBuilder.RegisterComponent(_gameplaySceneConfig);

            containerBuilder.Register<ICollisionRegistry, CollisionRegistry>(Lifetime.Singleton);
            containerBuilder.Register<IEntityViewFactory, EntityViewFactory>(Lifetime.Singleton);
            containerBuilder.Register<PlayerBuilder>(Lifetime.Singleton);
            containerBuilder.Register<UnitFactory>(Lifetime.Singleton);

            containerBuilder.BindViewWithPresenter<GameplayMainView, GameplayPresenter>(_gameplayMainView);
        }

        public override void OnResolve(IObjectResolver sceneResolver)
        {
            _world = World.Create();
            _world.UpdateByUnity = true;

            _world.AddFeature<InputFeature>(sceneResolver);
            _world.AddFeature<PlayerFeature>(sceneResolver);
            _world.AddFeature<UnitFeature>(sceneResolver);
            _world.AddFeature<ViewFeature>(sceneResolver);
            _world.AddFeature<StatsApplierFeature>(sceneResolver);
            _world.AddFeature<MoveFeature>(sceneResolver);
            _world.AddFeature<CooldownFeature>(sceneResolver);
            _world.AddFeature<AnimationFeature>(sceneResolver);
            _world.AddFeature<ProcessDestructedFeature>(sceneResolver);

            sceneResolver.ConstructView<GameplayMainView, GameplayPresenter>();
        }

        private void OnDestroy()
        {
            _world?.Dispose();
        }
    }
}