using GameCore.Gameplay.Features.Common.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Common.Destruct.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SelfDestructTimerSystem : ISystem
    {
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<SelfDestructTimer>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                ref var selfDestructTimer = ref entity.GetComponent<SelfDestructTimer>();

                if (selfDestructTimer.Value > 0)
                {
                    selfDestructTimer.Value -= deltaTime;
                }
                else
                {
                    entity.RemoveComponent<SelfDestructTimer>();
                    entity.AddComponent<DestructedTag>();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}