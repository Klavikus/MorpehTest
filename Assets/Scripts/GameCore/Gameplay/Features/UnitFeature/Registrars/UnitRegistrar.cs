using GameCore.Gameplay.Features.AnimationFeature;
using GameCore.Gameplay.Features.AnimationFeature.Components;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.PlayerFeature.Components;
using GameCore.Gameplay.Features.UnitFeature.Components;
using GameCore.Gameplay.Features.ViewFeature.Registrars;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.PlayerFeature.Registrars
{
    public class UnitRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Animator _animator;

        public override void RegisterComponents(Entity gameEntity)
        {
            gameEntity.AddComponent<UnitTag>();
            ref var transformComponent = ref gameEntity.AddComponent<TransformComponent>();
            transformComponent.Transform = transform;
            gameEntity.AddComponent<MoveDirectionComponent>();
            ref var moveSpeed = ref gameEntity.AddComponent<MoveSpeedComponent>();
            moveSpeed.Value = 0.5f;
            gameEntity.AddComponent<AlignRotationWithMoveDirectionTag>();
            gameEntity.AddComponent<MoveWithRotationTag>();
            gameEntity.AddComponent<RotationComponent>();
            ref var animatorComponent = ref gameEntity.AddComponent<AnimatorComponent>();
            animatorComponent.Value = _animator;
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<UnitTag>())
                gameEntity.RemoveComponent<UnitTag>();

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