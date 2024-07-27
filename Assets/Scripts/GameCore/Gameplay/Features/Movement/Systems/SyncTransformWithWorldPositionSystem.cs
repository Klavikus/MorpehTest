using GameCore.Gameplay.Common.View.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Movement.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SyncTransformWithWorldPositionSystem : ISystem
    {
        private Filter _entities;

        public void OnAwake()
        {
            _entities = World.Filter
                .With<TransformValue>()
                .With<WorldPositionValue>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _entities)
            {
                var transform = entity.GetComponent<TransformValue>().Value;
                transform.position = entity.GetComponent<WorldPositionValue>().Value;
            }
        }

        public void Dispose()
        {
        }
    }
}