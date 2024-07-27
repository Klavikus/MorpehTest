using GameCore.Gameplay.Common.View.Components;
using GameCore.Gameplay.Common.View.Registrars;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Common.Registrars
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents(Entity gameEntity)
        {
            ref var transformComponent = ref gameEntity.AddComponent<TransformValue>();
            transformComponent.Value = transform;
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<TransformValue>())
                gameEntity.RemoveComponent<TransformValue>();
        }
    }
}