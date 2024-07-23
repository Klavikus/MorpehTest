using GameCore.Gameplay.Features.Common.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.ViewFeature.Registrars
{
    public class TransformRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents(Entity gameEntity)
        {
            ref var transformComponent = ref gameEntity.AddComponent<TransformComponent>();
            transformComponent.Transform = transform;
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<TransformComponent>())
                gameEntity.RemoveComponent<TransformComponent>();
        }
    }
}