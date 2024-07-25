using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.MovingFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

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
                .With<WorldPosition>()
                .With<MoveDirectionComponent>()
                .With<MoveSpeedComponent>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movers)
            {
                ref var direction = ref entity.GetComponent<MoveDirectionComponent>();
                ref var speed = ref entity.GetComponent<MoveSpeedComponent>();

                if (speed.Value == 0)
                    continue;

                ref var worldPosition = ref entity.GetComponent<WorldPosition>();
                worldPosition.Value += direction.Value * (speed.Value * deltaTime);
            }
        }

        public void Dispose()
        {
        }
    }
}