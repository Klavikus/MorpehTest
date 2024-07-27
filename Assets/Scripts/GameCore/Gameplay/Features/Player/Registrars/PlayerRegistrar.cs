using GameCore.Gameplay.Common.View.Components;
using GameCore.Gameplay.Common.View.Registrars;
using GameCore.Gameplay.Features.Animation.Components;
using GameCore.Gameplay.Features.Movement.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.Player.Registrars
{
    public class PlayerRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Animator _animator;

        public override void RegisterComponents(Entity gameEntity)
        {
            gameEntity.AddComponent<Components.PlayerControl>();
            ref var transformComponent = ref gameEntity.AddComponent<TransformValue>();
            transformComponent.Value = transform;
            gameEntity.AddComponent<MoveDirectionValue>();
            gameEntity.AddComponent<MoveSpeedValue>();
            gameEntity.AddComponent<AlignRotationWithMoveDirection>();
            gameEntity.AddComponent<MoveWithRotation>();
            gameEntity.AddComponent<RotationValue>();
            ref var animatorComponent = ref gameEntity.AddComponent<AnimatorValue>();
            animatorComponent.Value = _animator;
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<Components.PlayerControl>())
                gameEntity.RemoveComponent<Components.PlayerControl>();

            if (gameEntity.Has<TransformValue>())
                gameEntity.RemoveComponent<TransformValue>();

            if (gameEntity.Has<MoveDirectionValue>())
                gameEntity.RemoveComponent<MoveDirectionValue>();
            if (gameEntity.Has<MoveSpeedValue>())
                gameEntity.RemoveComponent<MoveSpeedValue>();

            if (gameEntity.Has<MoveWithRotation>())
                gameEntity.RemoveComponent<MoveWithRotation>();
            if (gameEntity.Has<AlignRotationWithMoveDirection>())
                gameEntity.RemoveComponent<AlignRotationWithMoveDirection>();

            if (gameEntity.Has<AnimatorValue>())
                gameEntity.RemoveComponent<AnimatorValue>();
            if (gameEntity.Has<RotationValue>())
                gameEntity.RemoveComponent<RotationValue>();
        }
    }
}