﻿using GameCore.Domain.Common;
using GameCore.Domain.Configs;
using GameCore.Domain.Enums;
using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.AbilitiesFeature.Components;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.Common.Extensions;
using GameCore.Gameplay.Features.Cooldowns;
using GameCore.Gameplay.Features.Cooldowns.Components;
using GameCore.Gameplay.Features.PlayerFeature.Factories;
using GameCore.Gameplay.Features.StatsApplierFeature.Components;
using GameCore.Gameplay.Features.TargetCollection.Components;
using GameCore.Gameplay.Features.ViewFeature.Factory;
using GameCore.Infrastructure;
using GameCore.Infrastructure.Abstraction;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.PlayerFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class PlayerInitSystem : IInitializer, IInjectable
    {
        private IEntityViewFactory _entityViewFactory;
        private IConfigurationProvider _configurationProvider;
        private GameplayCamera _gameplayCamera;
        private Point _spawnPoint;
        private PlayerBuilder _playerBuilder;

        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _entityViewFactory = objectResolver.Resolve<IEntityViewFactory>();
            _configurationProvider = objectResolver.Resolve<IConfigurationProvider>();
            _gameplayCamera = objectResolver.Resolve<GameplayCamera>();
            _spawnPoint = objectResolver.Resolve<GameplaySceneConfig>().StartPoint;
            _playerBuilder = objectResolver.Resolve<PlayerBuilder>();
        }

        public async void OnAwake()
        {
            var entity = _playerBuilder.Build(World);

            var view = await _entityViewFactory.CreateForEntityAsync(
                entity,
                _configurationProvider.PlayerRegistrar.AssetGUID,
                _spawnPoint.Position,
                _spawnPoint.Rotation);

            entity.SetComponent(new LayerMask {Value = CollisionLayer.Hero.AsMask()});

            entity.AddComponent<SpeedApplySelfRequest>();

            _gameplayCamera.FocusTo(view.transform);

            var ability = World.CreateEntity();
            AbilityLevel abilityLevel = _configurationProvider.GetAbilityLevel(AbilityId.FireBolt, 1);

            ability.SetComponent(new AbilityIdComponent {Value = AbilityId.FireBolt});
            ability.SetComponent(new Cooldown() {Value = abilityLevel.Cooldown});

            ability.PutOnCooldown(abilityLevel.Cooldown);
            // CreateEntity.Empty()
            // .AddId(_identifierService.Next())
            // .AddAbilityId(AbilityId.VegetableBolt)
            // .AddCooldown(abilityLevel.Cooldown)
            // .With(x => x.isVegetableBoltAbility = true)
            // .PutOnCooldown(abilityLevel.Cooldown);
        }

        public void Dispose()
        {
        }
    }
}