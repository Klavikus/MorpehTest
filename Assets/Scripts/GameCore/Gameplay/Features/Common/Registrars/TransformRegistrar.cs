using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.ViewFeature.Registrars;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Common.Registrars
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