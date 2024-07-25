using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Common.Destruct.Systems;

namespace GameCore.Gameplay.Features.Common.Destruct
{
    public class ProcessDestructedFeature : Feature
    {
        public ProcessDestructedFeature()
        {
            AddSystem<SelfDestructTimerSystem>();
            AddCleanupSystem<CleanupGameDestructedViewSystem>();
            AddCleanupSystem<CleanupGameDestructedSystem>();
        }
    }
}