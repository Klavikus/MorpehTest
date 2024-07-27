using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Abilities.Systems;

namespace GameCore.Gameplay.Features.Abilities
{
    public class AbilitiesFeature : Feature
    {
        public AbilitiesFeature()
        {
            AddSystem<FireBoltAbilitySystem>();
        }
    }
}