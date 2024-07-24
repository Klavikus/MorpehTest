using Scellecs.Morpeh;

namespace GameCore.Gameplay.Common
{
    public static class EntityExtensions
    {
        public static ref TComponent GetOrAdd<TComponent>(this Entity entity)
            where TComponent : struct, IComponent
        {
            if (entity.Has<TComponent>())
                return ref entity.GetComponent<TComponent>();

            return ref entity.AddComponent<TComponent>();
        }
    }
}