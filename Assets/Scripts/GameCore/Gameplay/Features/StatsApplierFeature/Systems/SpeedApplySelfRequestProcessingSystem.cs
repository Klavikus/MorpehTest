using GameCore.Domain.Enums;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.Stats.Components;
using GameCore.Gameplay.Features.StatsApplierFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.StatsApplierFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SpeedApplySelfRequestProcessingSystem : ISystem
    {
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<StatsContainerComponent>()
                .With<MoveSpeedComponent>()
                .With<SpeedApplySelfRequest>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _entities)
            {
                ref var moveSpeed = ref entity.GetComponent<MoveSpeedComponent>();
                ref var statsContainer = ref entity.GetComponent<StatsContainerComponent>();

                moveSpeed.Value = statsContainer.Current.Get(BaseStatType.Speed);

                entity.RemoveComponent<SpeedApplySelfRequest>();
            }
        }

        public void Dispose()
        {
        }
    }
}