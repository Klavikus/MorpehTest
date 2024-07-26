using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.StatsApplierFeature.Components;
using GameCore.Gameplay.Features.Statuses.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Statuses.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ApplyFreezeStatusSystem : ISystem
    {
        private Filter _statuses;

        public World World { get; set; }

        public void OnAwake()
        {
            _statuses = World.Filter
                .With<StatusTag>()
                .With<FreezeTag>()
                .With<ProducerId>()
                .With<TargetId>()
                .With<EffectValue>()
                .Without<AffectedTag>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity status in _statuses)
            {
                var entity = World.CreateEntity();

                entity.AddComponent<SpeedApplySelfRequest>();
                entity.SetComponent(new TargetId {Value = status.GetComponent<TargetId>().Value});
                entity.SetComponent(new ProducerId {Value = status.GetComponent<ProducerId>().Value});
                entity.SetComponent(new EffectValue {Value = status.GetComponent<EffectValue>().Value});
                entity.SetComponent(new ApplierStatusLink {Value = status.ID});
                entity.AddComponent<AffectedTag>();
            }
        }

        public void Dispose()
        {
        }
    }
}