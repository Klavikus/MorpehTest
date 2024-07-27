using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.StatsApplier.Systems;

namespace GameCore.Gameplay.Features.StatsApplier
{
    public class StatsApplierFeature : Feature
    {
        public StatsApplierFeature()
        {
            AddSystem<SpeedApplySelfRequestProcessingSystem>();
        }
    }
}