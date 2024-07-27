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
        private Stash<TransformValue> _transformStash;

        public World World { get; set; }

        public void OnAwake()
        {
            _chaseUnits = World.Filter
                .With<Unit>()
                .With<TransformValue>()
                .With<MoveDirectionValue>()
                .With<ChaseTargetValue>()
                .Build();

            _transformStash = World.GetStash<TransformValue>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity chaseUnit in _chaseUnits)
            {
                ref var chase = ref chaseUnit.GetComponent<ChaseTargetValue>();

                bool targetEntityExist = World.TryGetEntity(chase.Value, out Entity chaseTarget);

                if (targetEntityExist == false || _transformStash.Has(chaseTarget) == false)
                    return;

                ref var moveDirection = ref chaseUnit.GetComponent<MoveDirectionValue>();
                var transform = _transformStash.Get(chaseUnit).Value;

                var targetTransform =_transformStash.Get(chaseTarget).Value;

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