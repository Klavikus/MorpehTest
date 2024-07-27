using GameCore.Gameplay.Common.Destruct.Systems;

namespace GameCore.Gameplay.Common.Destruct
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