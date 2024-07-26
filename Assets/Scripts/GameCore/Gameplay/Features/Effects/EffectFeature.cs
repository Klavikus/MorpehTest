using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Effects.Systems;

namespace GameCore.Gameplay.Features.Effects
{
    public sealed class EffectFeature : Feature
    {
        public EffectFeature()
        {
            AddSystem<RemoveEffectsWithoutTargetsSystem>();
            AddSystem<ProcessDamageEffectSystem>();
            AddSystem<ProcessHealEffectSystem>();
            AddCleanupSystem<CleanupProcessedEffects>();
        }
    }
}