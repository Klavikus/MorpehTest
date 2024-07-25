using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.MovingFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.MovingFeature.Systems
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
                .With<TransformComponent>()
                .With<WorldPosition>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _entities)
            {
                var transform = entity.GetComponent<TransformComponent>().Transform;
                transform.position = entity.GetComponent<WorldPosition>().Value;
            }
        }

        public void Dispose()
        {
        }
    }
}