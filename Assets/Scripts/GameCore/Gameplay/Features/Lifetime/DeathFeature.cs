using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Lifetime.Systems;

namespace GameCore.Gameplay.Features.Lifetime
{
    public sealed class DeathFeature : Feature
    {
        public DeathFeature()
        {
            AddSystem<MarkDeadSystem>();
        }
    }
}