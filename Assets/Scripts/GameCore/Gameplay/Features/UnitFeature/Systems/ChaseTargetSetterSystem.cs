using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.PlayerFeature.Components;
using GameCore.Gameplay.Features.UnitFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.UnitFeature.Systems
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
                .With<UnitTag>()
                .With<TransformComponent>()
                .With<MoveDirectionComponent>()
                .Without<ChaseComponent>()
                .Build();

            _players = World.Filter
                .With<PlayerTagComponent>()
                .With<TransformComponent>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity player in _players)
            {
                foreach (Entity unit in _chaseUnits)
                {
                    ref var chase = ref unit.AddComponent<ChaseComponent>();
                    chase.TargetEntity = player;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}