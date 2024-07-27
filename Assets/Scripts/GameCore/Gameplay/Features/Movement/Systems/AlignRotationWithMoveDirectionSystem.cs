using GameCore.Gameplay.Features.Common;
using GameCore.Gameplay.Features.MovingFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using VContainer;

namespace GameCore.Gameplay.Features.MovingFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class AlignRotationWithMoveDirectionSystem : ISystem
    {
        private Filter _movers;

        public void OnAwake()
        {
            _movers = World.Filter
                .With<AlignRotationWithMoveDirection>()
                .With<RotationValue>()
                .With<MoveDirectionValue>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movers)
            {
                ref var direction = ref entity.GetComponent<MoveDirectionValue>();

                if (direction.Value == Vector3.zero)
                    continue;

                ref var rotation = ref entity.GetComponent<RotationValue>();
                rotation.Value = Quaternion.LookRotation(direction.Value);
            }
        }

        public void Dispose()
        {
        }
    }
}