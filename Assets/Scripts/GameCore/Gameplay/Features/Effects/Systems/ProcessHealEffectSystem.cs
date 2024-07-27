using GameCore.Gameplay.Features.Armaments.Components;
using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.Lifetime.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GameCore.Gameplay.Features.Effects.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ProcessHealEffectSystem : ISystem
    {
        private Filter _effects;

        public World World { get; set; }

        public void OnAwake()
        {
            _effects = World.Filter
                .With<HealEffect>()
                .With<EffectValue>()
                .With<TargetIdValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity effect in _effects)
            {
                if (World.TryGetEntity(effect.GetComponent<TargetIdValue>().Value, out Entity target) == false)
                    continue;

                effect.AddComponent<Processed>();

                if (target.Has<Dead>())
                    continue;

                if (target.Has<MaxHpValue>() && target.Has<CurrentHpValue>())
                {
                    float newValue = Mathf.Min(
                        target.GetComponent<CurrentHpValue>().Value + effect.GetComponent<EffectValue>().Value,
                        target.GetComponent<MaxHpValue>().Value);
                    ref var currentHp = ref target.GetComponent<CurrentHpValue>();
                    currentHp.Value = newValue;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}