using GameCore.Gameplay.Features.Armaments.Components;
using GameCore.Gameplay.Features.Effects.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Effects.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CleanupProcessedEffects : ICleanupSystem
    {
        private Filter _effects;

        public World World { get; set; }

        public void OnAwake()
        {
            _effects = World.Filter
                .With<EffectTag>()
                .With<ProcessedTag>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity effect in _effects)
                World.RemoveEntity(effect);
        }

        public void Dispose()
        {
        }
    }
}