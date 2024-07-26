using GameCore.Gameplay.Features.AbilitiesFeature.Armaments.Components;
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
                .With<HealEffectTag>()
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

                if (target.Has<MaxHp>() && target.Has<CurrentHp>())
                {
                    float newValue = Mathf.Min(
                        target.GetComponent<CurrentHp>().Value + effect.GetComponent<EffectValue>().Value,
                        target.GetComponent<MaxHp>().Value);
                    ref var currentHp = ref target.GetComponent<CurrentHp>();
                    currentHp.Value = newValue;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}