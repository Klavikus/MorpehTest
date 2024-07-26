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
        private Filter _cooldownables;

        public World World { get; set; }

        public void OnAwake()
        {
            _cooldownables = World.Filter
                .With<Cooldown>()
                .With<CooldownLeft>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _cooldownables)
            {
                ref var cooldownLeft = ref entity.GetComponent<CooldownLeft>();
                cooldownLeft.Value -= deltaTime;

                if (cooldownLeft.Value <= 0)
                {
                    entity.AddComponent<CooldownUp>();
                    entity.RemoveComponent<CooldownLeft>();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}