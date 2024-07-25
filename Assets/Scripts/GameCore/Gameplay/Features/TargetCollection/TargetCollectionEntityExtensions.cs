using Scellecs.Morpeh;

namespace Code.Gameplay.Features.TargetCollection
{
    public static class TargetCollectionEntityExtensions
    {
        public static Entity RemoveTargetCollectionComponents(this Entity entity)
        {
            if (entity.Has<TargetsBuffer>())
                entity.RemoveComponent<TargetsBuffer>();
          
            if (entity.Has<CollectTargetsInterval>())
                entity.RemoveComponent<CollectTargetsInterval>();
          
            if (entity.Has<CollectTargetsTimer>())
                entity.RemoveComponent<CollectTargetsTimer>();
           
            if (entity.Has<ReadyToCollectTargets>())
                entity.RemoveComponent<ReadyToCollectTargets>();

            return entity;
        }
    }
}