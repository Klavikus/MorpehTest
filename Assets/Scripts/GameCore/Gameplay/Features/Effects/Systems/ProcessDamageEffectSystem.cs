using GameCore.Gameplay.Common.Components;
using GameCore.Gameplay.Features.Armaments.Components;
using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.Lifetime.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Effects.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ProcessDamageEffectSystem : ISystem
    {
        private Filter _effects;

        public World World { get; set; }

        public void OnAwake()
        {
            _effects = World.Filter
                .With<DamageEffectTag>()
                .With<EffectValue>()
                .With<TargetId>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity effect in _effects)
            {
                if (World.TryGetEntity(effect.GetComponent<TargetId>().Value, out Entity target) == false)
                    continue;

                effect.AddComponent<ProcessedTag>();

                if (target.Has<DeadTag>())
                    continue;

                if (target.Has<CurrentHp>() == false)
                    continue;

                ref var currentHp = ref target.GetComponent<CurrentHp>();

                currentHp.Value -= effect.GetComponent<EffectValue>().Value;

                if (target.Has<DamageTakerAnimatorComponent>())
                    target.GetComponent<DamageTakerAnimatorComponent>().Value.PlayDamageTaken();
            }
        }

        public void Dispose()
        {
        }
    }
}