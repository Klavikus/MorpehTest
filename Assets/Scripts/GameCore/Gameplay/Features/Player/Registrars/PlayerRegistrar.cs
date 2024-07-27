using GameCore.Gameplay.Features.AnimationFeature;
using GameCore.Gameplay.Features.AnimationFeature.Components;
using GameCore.Gameplay.Features.Common.Components;
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
            gameEntity.AddComponent<Player>();
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
            if (gameEntity.Has<Player>())
                gameEntity.RemoveComponent<Player>();

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