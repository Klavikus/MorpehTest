using GameCore.Gameplay.Features.MovingFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.MovingFeature.Systems
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
                .With<TransformComponent>()
                .With<RotationComponent>()
                .Without<MoveWithRotationTag>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _rotators)
            {
                ref var rotation = ref entity.GetComponent<RotationComponent>();

                var transform = entity.GetComponent<TransformComponent>().Transform;
                transform.rotation = rotation.Value;
            }
        }

        public void Dispose()
        {
        }
    }
}