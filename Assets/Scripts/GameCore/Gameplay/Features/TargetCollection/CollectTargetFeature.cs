using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.TargetCollection.Systems;

namespace GameCore.Gameplay.Features.TargetCollection
{
    public class CollectTargetFeature : Feature
    {
        public CollectTargetFeature()
        {
            AddSystem<CollectTargetIntervalSystem>();
            AddSystem<CastForTargetsWithLimitSystem>();
            AddSystem<CastForTargetsNoLimitSystem>();
            AddSystem<ReadyToBounceWhenFindTargetSystem>();
            // AddSystem<SetDirectionToNewTargetForBounceSystem>();
            AddSystem<MarkReachedSystem>();
            AddCleanupSystem<CleanupTargetBuffersSystem>();
        }
    }
}