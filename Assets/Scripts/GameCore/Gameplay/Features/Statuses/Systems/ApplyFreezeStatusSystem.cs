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
                .With<Status>()
                .With<Freeze>()
                .With<ProducerIdValue>()
                .With<TargetIdValue>()
                .With<EffectValue>()
                .Without<Affected>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity status in _statuses)
            {
                var entity = World.CreateEntity();

                entity.AddComponent<SpeedApplySelfRequest>();
                entity.SetComponent(new TargetIdValue {Value = status.GetComponent<TargetIdValue>().Value});
                entity.SetComponent(new ProducerIdValue {Value = status.GetComponent<ProducerIdValue>().Value});
                entity.SetComponent(new EffectValue {Value = status.GetComponent<EffectValue>().Value});
                entity.SetComponent(new ApplierStatusLinkValue {Value = status.ID});
                entity.AddComponent<Affected>();
            }
        }

        public void Dispose()
        {
        }
    }
}