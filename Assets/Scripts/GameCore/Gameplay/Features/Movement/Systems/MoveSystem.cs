using GameCore.Gameplay.Common.View.Components;
using GameCore.Gameplay.Features.Movement.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Movement.Systems
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
                .With<WorldPositionValue>()
                .With<MoveDirectionValue>()
                .With<MoveSpeedValue>()
                .Build();
        }

        public World World { get; set; }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _movers)
            {
                ref var direction = ref entity.GetComponent<MoveDirectionValue>();
                ref var speed = ref entity.GetComponent<MoveSpeedValue>();

                if (speed.Value == 0)
                    continue;

                ref var worldPosition = ref entity.GetComponent<WorldPositionValue>();
                worldPosition.Value += direction.Value * (speed.Value * deltaTime);
            }
        }

        public void Dispose()
        {
        }
    }
}