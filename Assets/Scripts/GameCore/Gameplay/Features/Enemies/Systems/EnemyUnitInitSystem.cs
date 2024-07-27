using GameCore.Domain.Common;
using GameCore.Domain.Configs;
using GameCore.Gameplay.Common;
using GameCore.Gameplay.Common.Extensions;
using GameCore.Gameplay.Common.View.Factory;
using GameCore.Gameplay.Features.Lifetime.Components;
using GameCore.Gameplay.Features.StatsApplier.Components;
using GameCore.Gameplay.Features.TargetCollection.Components;
using GameCore.Gameplay.Features.Units.Factories;
using GameCore.Infrastructure.Abstraction;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.Units.Systems
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
        private UnitFactory _unitFactory;
        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _entityViewFactory = objectResolver.Resolve<IEntityViewFactory>();
            _configurationProvider = objectResolver.Resolve<IConfigurationProvider>();
            _spawnPoint = objectResolver.Resolve<GameplaySceneConfig>().EnemyPoint;
            _unitFactory = objectResolver.Resolve<UnitFactory>();
        }

        public async void OnAwake()
        {
            var entity = _unitFactory.CreateDefaultUnit(World);

            var view = await _entityViewFactory.CreateForEntityAsync(
                entity,
                _configurationProvider.EnemyRegistrar.AssetGUID,
                _spawnPoint.Position,
                _spawnPoint.Rotation);
            entity.SetComponent(new LayerMaskValue {Value = CollisionLayer.Enemy.AsMask()});

            view.GameObject.layer = (int) CollisionLayer.Enemy;
            entity.SetComponent(new MaxHpValue {Value = 100});
            entity.SetComponent(new CurrentHpValue {Value = 100});

            entity.AddComponent<SpeedApplySelfRequest>();
        }

        public void Dispose()
        {
        }
    }
}