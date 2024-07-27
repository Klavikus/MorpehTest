using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.MovingFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.MovingFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class MoveWithRotationSystem : ISystem
    {
        private Filter _movers;

        public void OnAwake()
        {
            _movers = World.Filter
                .With<TransformValue>()
                .With<WorldPositionValue>()
                .With<RotationValue>()
                .With<MoveWithRotation>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movers)
            {
                ref var position = ref entity.GetComponent<WorldPositionValue>();
                ref var rotation = ref entity.GetComponent<RotationValue>();

                var transform = entity.GetComponent<TransformValue>().Value;

                transform.SetPositionAndRotation(position.Value, rotation.Value);
            }
        }

        public void Dispose()
        {
        }
    }
}