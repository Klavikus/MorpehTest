using GameCore.Gameplay.Features.AnimationFeature;
using GameCore.Gameplay.Features.AnimationFeature.Components;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.PlayerFeature.Components;
using GameCore.Gameplay.Features.ViewFeature.Registrars;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.PlayerFeature.Registrars
{
    public class PlayerRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Animator _animator;

        public override void RegisterComponents(Entity gameEntity)
        {
            gameEntity.AddComponent<PlayerTagComponent>();
            ref var transformComponent = ref gameEntity.AddComponent<TransformComponent>();
            transformComponent.Transform = transform;
            gameEntity.AddComponent<MoveDirectionComponent>();
            gameEntity.AddComponent<MoveSpeedComponent>();
            gameEntity.AddComponent<AlignRotationWithMoveDirectionTag>();
            gameEntity.AddComponent<MoveWithRotationTag>();
            gameEntity.AddComponent<RotationComponent>();
            ref var animatorComponent = ref gameEntity.AddComponent<AnimatorComponent>();
            animatorComponent.Value = _animator;
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<PlayerTagComponent>())
                gameEntity.RemoveComponent<PlayerTagComponent>();

            if (gameEntity.Has<TransformComponent>())
                gameEntity.RemoveComponent<TransformComponent>();

            if (gameEntity.Has<MoveDirectionComponent>())
                gameEntity.RemoveComponent<MoveDirectionComponent>();
            if (gameEntity.Has<MoveSpeedComponent>())
                gameEntity.RemoveComponent<MoveSpeedComponent>();

            if (gameEntity.Has<MoveWithRotationTag>())
                gameEntity.RemoveComponent<MoveWithRotationTag>();
            if (gameEntity.Has<AlignRotationWithMoveDirectionTag>())
                gameEntity.RemoveComponent<AlignRotationWithMoveDirectionTag>();

            if (gameEntity.Has<AnimatorComponent>())
                gameEntity.RemoveComponent<AnimatorComponent>();
            if (gameEntity.Has<RotationComponent>())
                gameEntity.RemoveComponent<RotationComponent>();
        }
    }
}