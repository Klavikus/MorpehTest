using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.Views.Registrars;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.PlayerFeature
{
    public class PlayerRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents(Entity gameEntity)
        {
            gameEntity.AddComponent<PlayerTagComponent>();
            ref var transformComponent = ref gameEntity.AddComponent<TransformComponent>();
            transformComponent.Transform = transform;
            gameEntity.AddComponent<MoveComponent>();
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<PlayerTagComponent>())
                gameEntity.RemoveComponent<PlayerTagComponent>();
            if (gameEntity.Has<TransformComponent>())
                gameEntity.RemoveComponent<TransformComponent>();
            if (gameEntity.Has<MoveComponent>())
                gameEntity.RemoveComponent<MoveComponent>();
        }
    }
}