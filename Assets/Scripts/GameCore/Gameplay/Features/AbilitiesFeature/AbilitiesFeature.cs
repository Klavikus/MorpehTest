using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.AbilitiesFeature.Systems;

namespace GameCore.Gameplay.Features.AbilitiesFeature
{
    public class AbilitiesFeature : Feature
    {
        public AbilitiesFeature()
        {
            AddSystem<FireBoltAbilitySystem>();
        }
    }
}