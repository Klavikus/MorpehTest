using GameCore.Gameplay.Features.MovingFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace GameCore.Gameplay.Features.MovingFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class MoveSystem : ISystem
    {
        private Filter _movers;

        public void OnAwake()
        {
            _movers = World.Filter
                .With<TransformComponent>()
                .With<MoveComponent>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movers)
            {
                ref var moveComponent = ref entity.GetComponent<MoveComponent>();

                if (moveComponent.Speed == 0)
                    continue;

                var transform = entity.GetComponent<TransformComponent>().Transform;
                transform.Translate(moveComponent.Direction * (moveComponent.Speed * deltaTime));
            }
        }

        public void Dispose()
        {
        }
    }
}