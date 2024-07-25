using Code.Gameplay.Features.Lifetime.Systems;
using GameCore.Gameplay.Common;

namespace Code.Gameplay.Features.Lifetime
{
    public sealed class DeathFeature : Feature
    {
        public DeathFeature()
        {
            AddSystem<MarkDeadSystem>();
        }
    }
}