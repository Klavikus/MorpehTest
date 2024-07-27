using GameCore.Domain.Enums;
using GameCore.Gameplay.Common.Components;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.Stats.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.StatsApplierFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ApplyStatsRequestCleanupSystem : ISystem
    {
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<ApplyStatsSelfRequest>()
                .Without<CreateInProgress>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _entities)
            {
                entity.RemoveComponent<ApplyStatsSelfRequest>();
            }
        }

        public void Dispose()
        {
        }
    }
}