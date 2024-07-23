using GameCore.Gameplay.Features.UnitFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.UnitFeature.Systems
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
                .With<UnitTag>()
                .With<ChaseComponent>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity unit in _chaseUnits)
            {
                if (unit.GetComponent<ChaseComponent>().TargetEntity.IsNullOrDisposed())
                    unit.RemoveComponent<ChaseComponent>();
            }
        }

        public void Dispose()
        {
        }
    }
}