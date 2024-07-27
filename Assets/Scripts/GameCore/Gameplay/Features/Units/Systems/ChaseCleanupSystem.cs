using GameCore.Gameplay.Features.Units.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Units.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ChaseCleanupSystem : ICleanupSystem
    {
        private Filter _chaseUnits;
        public World World { get; set; }

        public void OnAwake()
        {
            _chaseUnits = World.Filter
                .With<Unit>()
                .With<ChaseTargetValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity unit in _chaseUnits)
            {
                bool entityExist = World.TryGetEntity(unit.GetComponent<ChaseTargetValue>().Value, out var target);

                if ((entityExist && target.IsNullOrDisposed()) || entityExist == false)
                {
                    unit.RemoveComponent<ChaseTargetValue>();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}