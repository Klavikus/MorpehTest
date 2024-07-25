using Code.Common.Destruct.Systems;
using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Common.Destruct.Systems;

namespace Code.Common
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