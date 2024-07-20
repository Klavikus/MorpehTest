using Scellecs.Morpeh;

namespace GameCore.Gameplay.Common.Collisions
{
  public interface ICollisionRegistry
  {
    void Register(int instanceId, Entity entity);
    void Unregister(int instanceId);
    TEntity Get<TEntity>(int instanceId) where TEntity : class;
  }
}