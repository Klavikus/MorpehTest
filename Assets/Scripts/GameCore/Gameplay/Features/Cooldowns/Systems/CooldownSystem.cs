using GameCore.Gameplay.Features.Cooldowns.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Cooldowns.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CooldownSystem : ISystem
    {
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<CooldownValue>()
                .With<CooldownLeftValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                ref var cooldownLeft = ref entity.GetComponent<CooldownLeftValue>();
                cooldownLeft.Value -= deltaTime;

                if (cooldownLeft.Value <= 0)
                {
                    entity.AddComponent<CooldownUp>();
                    entity.RemoveComponent<CooldownLeftValue>();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}