using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.UnitFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GameCore.Gameplay.Features.UnitFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ChaseTargetSystem : ISystem
    {
        private Filter _chaseUnits;

        public World World { get; set; }

        public void OnAwake()
        {
            _chaseUnits = World.Filter
                .With<UnitTag>()
                .With<TransformComponent>()
                .With<MoveDirectionComponent>()
                .With<ChaseComponent>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity chaseUnit in _chaseUnits)
            {
                ref var chase = ref chaseUnit.GetComponent<ChaseComponent>();

                if (chase.TargetEntity.Has<TransformComponent>() == false)
                    return;

                ref var moveDirection = ref chaseUnit.GetComponent<MoveDirectionComponent>();
                var transform = chaseUnit.GetComponent<TransformComponent>().Transform;

                var targetTransform = chase.TargetEntity.GetComponent<TransformComponent>().Transform;

                var directionToTarget = targetTransform.position - transform.position;
                var sqrDistance = directionToTarget.sqrMagnitude;

                moveDirection.Value = sqrDistance <= 1
                    ? Vector3.zero
                    : Vector3.Normalize(targetTransform.position - transform.position);
            }
        }

        public void Dispose()
        {
        }
    }
}