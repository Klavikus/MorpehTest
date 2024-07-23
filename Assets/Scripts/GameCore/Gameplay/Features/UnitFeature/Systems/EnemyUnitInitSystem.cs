﻿using GameCore.Domain.Common;
using GameCore.Domain.Configs;
using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.PlayerFeature.Components;
using GameCore.Gameplay.Features.UnitFeature.Components;
using GameCore.Gameplay.Features.ViewFeature.Factory;
using GameCore.Infrastructure;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.UnitFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class EnemyUnitInitSystem : IInitializer, IInjectable
    {
        private Filter _chaseUnits;
        private Filter _players;

        private IEntityViewFactory _entityViewFactory;
        private IConfigurationProvider _configurationProvider;
        private Point _spawnPoint;
        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _entityViewFactory = objectResolver.Resolve<IEntityViewFactory>();
            _configurationProvider = objectResolver.Resolve<IConfigurationProvider>();
            _spawnPoint = objectResolver.Resolve<GameplaySceneConfig>().EnemyPoint;
        }

        public async void OnAwake()
        {
            var entity = World.CreateEntity();

            var view = await _entityViewFactory.CreateForEntityAsync(
                entity,
                _configurationProvider.EnemyRegistrar.AssetGUID,
                _spawnPoint.Position,
                _spawnPoint.Rotation);
        }

        public void Dispose()
        {
        }
    }
}