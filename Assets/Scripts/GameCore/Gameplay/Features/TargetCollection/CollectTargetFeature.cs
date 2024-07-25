using Code.Gameplay.Features.TargetCollection.Systems;
using GameCore.Gameplay.Common;

namespace Code.Gameplay.Features.TargetCollection
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