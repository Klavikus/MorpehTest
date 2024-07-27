using GameCore.Gameplay.Common.View.Components;
using GameCore.Gameplay.Features.Movement.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Movement.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class RotationSystem : ISystem
    {
        private Filter _rotators;

        public void OnAwake()
        {
            _rotators = World.Filter
                .With<TransformValue>()
                .With<RotationValue>()
                .Without<MoveWithRotation>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _rotators)
            {
                ref var rotation = ref entity.GetComponent<RotationValue>();

                var transform = entity.GetComponent<TransformValue>().Value;
                transform.rotation = rotation.Value;
            }
        }

        public void Dispose()
        {
        }
    }
}