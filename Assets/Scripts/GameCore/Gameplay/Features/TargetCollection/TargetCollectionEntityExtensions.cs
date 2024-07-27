using GameCore.Gameplay.Features.TargetCollection.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.TargetCollection
{
    public static class TargetCollectionEntityExtensions
    {
        public static Entity RemoveTargetCollectionComponents(this Entity entity)
        {
            if (entity.Has<TargetsBufferValue>())
                entity.RemoveComponent<TargetsBufferValue>();
          
            if (entity.Has<CollectTargetsIntervalValue>())
                entity.RemoveComponent<CollectTargetsIntervalValue>();
          
            if (entity.Has<CollectTargetsTimerValue>())
                entity.RemoveComponent<CollectTargetsTimerValue>();
           
            if (entity.Has<ReadyToCollectTargets>())
                entity.RemoveComponent<ReadyToCollectTargets>();

            return entity;
        }
    }
}