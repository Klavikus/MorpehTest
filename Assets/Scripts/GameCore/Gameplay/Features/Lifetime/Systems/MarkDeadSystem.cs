using GameCore.Gameplay.Features.Lifetime.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Lifetime.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class MarkDeadSystem : ISystem
    {
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<CurrentHp>()
                .With<MaxHp>()
                .Without<DeadTag>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                if (entity.GetComponent<CurrentHp>().Value > 0)
                    continue;

                entity.AddComponent<DeadTag>();
                entity.AddComponent<ProcessingDeathTag>();
            }
        }

        public void Dispose()
        {
        }
    }
}