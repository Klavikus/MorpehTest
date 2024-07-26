using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.EffectApplication.Systems;

namespace GameCore.Gameplay.Features.EffectApplication
{
    public class EffectApplicationFeature : Feature
    {
        public EffectApplicationFeature()
        {
            AddSystem<ApplyEffectsOnTargetsSystem>();
            AddSystem<ApplyStatusesOnTargetsSystem>();
        }
    }
}