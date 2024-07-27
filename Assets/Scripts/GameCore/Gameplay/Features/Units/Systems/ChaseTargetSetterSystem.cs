using GameCore.Gameplay.Common.View.Components;
using GameCore.Gameplay.Features.Movement.Components;
using GameCore.Gameplay.Features.Units.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Units.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ChaseTargetSetterSystem : ISystem
    {
        private Filter _chaseUnits;
        private Filter _players;
        public World World { get; set; }

        public void OnAwake()
        {
            _chaseUnits = World.Filter
                .With<Unit>()
                .With<TransformValue>()
                .With<MoveDirectionValue>()
                .Without<ChaseTargetValue>()
                .Build();

            _players = World.Filter
                .With<Player.Components.Player>()
                .With<TransformValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity player in _players)
            {
                foreach (Entity unit in _chaseUnits)
                {
                    ref var chase = ref unit.AddComponent<ChaseTargetValue>();
                    chase.Value = player.ID;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}