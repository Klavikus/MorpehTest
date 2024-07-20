using System.Collections.Generic;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Common.Collisions
{
  public class CollisionRegistry : ICollisionRegistry
  {
      private readonly Dictionary<int, Entity> _entityByInstanceId = new();

      public void Register(int instanceId, Entity entity)
      {
        _entityByInstanceId[instanceId] = entity;
      }

      public void Unregister(int instanceId)
      {
        if (_entityByInstanceId.ContainsKey(instanceId))
          _entityByInstanceId.Remove(instanceId);
      }

      public TEntity Get<TEntity>(int instanceId) where TEntity : class
      {
        return _entityByInstanceId.TryGetValue(instanceId, out Entity entity) 
          ? entity as TEntity
          : null;
      }
  }
}