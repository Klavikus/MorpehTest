using GameCore.Controllers.Implementation.Presenters.Gameplay;
using GameCore.Domain.Configs;
using GameCore.Extensions;
using GameCore.Gameplay.Common;
using GameCore.Gameplay.Common.Collisions;
using GameCore.Gameplay.Common.Destruct;
using GameCore.Gameplay.Common.Physic;
using GameCore.Gameplay.Common.View;
using GameCore.Gameplay.Common.View.Factory;
using GameCore.Gameplay.Features.Abilities;
using GameCore.Gameplay.Features.Animation;
using GameCore.Gameplay.Features.Armaments.Factory;
using GameCore.Gameplay.Features.Cooldowns;
using GameCore.Gameplay.Features.EffectApplication;
using GameCore.Gameplay.Features.Effects;
using GameCore.Gameplay.Features.Effects.Factory;
using GameCore.Gameplay.Features.Input;
using GameCore.Gameplay.Features.Lifetime;
using GameCore.Gameplay.Features.Movement;
using GameCore.Gameplay.Features.Player;
using GameCore.Gameplay.Features.Player.Factories;
using GameCore.Gameplay.Features.StatsApplier;
using GameCore.Gameplay.Features.Statuses;
using GameCore.Gameplay.Features.Statuses.Applier;
using GameCore.Gameplay.Features.Statuses.Factory;
using GameCore.Gameplay.Features.TargetCollection;
using GameCore.Gameplay.Features.Units;
using GameCore.Gameplay.Features.Units.Factories;
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
            containerBuilder.Register<IPhysicsService, PhysicsService>(Lifetime.Singleton);
            containerBuilder.Register<IEntityViewFactory, EntityViewFactory>(Lifetime.Singleton);
            containerBuilder.Register<IArmamentsFactory, ArmamentsFactory>(Lifetime.Singleton);
            containerBuilder.Register<IEffectFactory, EffectFactory>(Lifetime.Singleton);
            containerBuilder.Register<IStatusFactory, StatusFactory>(Lifetime.Singleton);
            containerBuilder.Register<IStatusApplier, StatusApplier>(Lifetime.Singleton);
            containerBuilder.Register<PlayerBuilder>(Lifetime.Singleton);
            containerBuilder.Register<UnitFactory>(Lifetime.Singleton);

            containerBuilder.BindViewWithPresenter<GameplayMainView, GameplayPresenter>(_gameplayMainView);
        }

        public override void OnResolve(IObjectResolver sceneResolver)
        {
            _world = World.Create();
            _world.UpdateByUnity = true;

            
            _world.AddFeature<ViewFeature>(sceneResolver);
            
            _world.AddFeature<InputFeature>(sceneResolver);
            
            _world.AddFeature<PlayerFeature>(sceneResolver);
            _world.AddFeature<DeathFeature>(sceneResolver);
            _world.AddFeature<UnitFeature>(sceneResolver);

            _world.AddFeature<CooldownFeature>(sceneResolver);
            _world.AddFeature<AbilitiesFeature>(sceneResolver);

            _world.AddFeature<CollectTargetFeature>(sceneResolver);
       
            _world.AddFeature<EffectApplicationFeature>(sceneResolver);

            _world.AddFeature<StatsApplierFeature>(sceneResolver);
            _world.AddFeature<AnimationFeature>(sceneResolver);
            _world.AddFeature<StatusFeature>(sceneResolver);
            _world.AddFeature<EffectFeature>(sceneResolver);

            _world.AddFeature<MoveFeature>(sceneResolver);

            _world.AddFeature<ProcessDestructedFeature>(sceneResolver);
            
            sceneResolver.ConstructView<GameplayMainView, GameplayPresenter>();
        }

        private void OnDestroy()
        {
            _world?.Dispose();
        }
    }
}