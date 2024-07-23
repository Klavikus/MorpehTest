using GameCore.Domain.Enums;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.Stats.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.MovingFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SetSpeedFromStatsSystem : ISystem
    {
        private Filter _rotators;

        public void OnAwake()
        {
            _rotators = World.Filter
                .With<StatsContainerComponent>()
                .With<MoveSpeedComponent>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _rotators)
            {
                ref var moveSpeed = ref entity.GetComponent<MoveSpeedComponent>();
                ref var statsContainer = ref entity.GetComponent<StatsContainerComponent>();

                moveSpeed.Value = statsContainer.Current.Get(BaseStatType.Speed);
            }
        }

        public void Dispose()
        {
        }
    }
}