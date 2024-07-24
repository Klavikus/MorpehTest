using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.StatsApplierFeature.Systems;

namespace GameCore.Gameplay.Features.StatsApplierFeature
{
    public class StatsApplierFeature : Feature
    {
        public StatsApplierFeature()
        {
            AddSystem<SpeedApplySelfRequestProcessingSystem>();
        }
    }
}