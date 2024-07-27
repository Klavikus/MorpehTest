using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Effects;
using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.Effects.Factory;
using GameCore.Gameplay.Features.Statuses.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.Statuses.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class PeriodicDamageStatusSystem : ISystem, IInjectable
    {
        private IEffectFactory _effectFactory;

        private Filter _statuses;
        private Stash<EffectValue> _effectValueStash;
        private Stash<PeriodValue> _periodStash;
        private Stash<TimeSinceLastTickValue> _timeSinceLastTickStash;
        private Stash<ProducerIdValue> _producerIdStash;
        private Stash<TargetIdValue> _targetIdStash;

        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _effectFactory = objectResolver.Resolve<IEffectFactory>();
        }

        public void OnAwake()
        {
            _statuses = World.Filter
                .With<Status>()
                .With<EffectValue>()
                .With<PeriodValue>()
                .With<TimeSinceLastTickValue>()
                .With<ProducerIdValue>()
                .With<TargetIdValue>()
                .Build();

            _effectValueStash = World.GetStash<EffectValue>();
            _periodStash = World.GetStash<PeriodValue>();
            _timeSinceLastTickStash = World.GetStash<TimeSinceLastTickValue>();
            _producerIdStash = World.GetStash<ProducerIdValue>();
            _targetIdStash = World.GetStash<TargetIdValue>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity status in _statuses)
            {
                ref var timeSinceLastTick = ref _timeSinceLastTickStash.Get(status);

                if (timeSinceLastTick.Value >= 0)
                {
                    timeSinceLastTick.Value -= deltaTime;
                }
                else
                {
                    timeSinceLastTick.Value -= _periodStash.Get(status).Value;

                    _effectFactory.Create(
                        World,
                        new EffectSetup
                            {EffectTypeId = EffectTypeId.Damage, Value = _effectValueStash.Get(status).Value},
                        _producerIdStash.Get(status).Value,
                        _targetIdStash.Get(status).Value);
                }
            }
        }

        public void Dispose()
        {
        }
    }
}