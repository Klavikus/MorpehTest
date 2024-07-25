using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CollectTargetIntervalSystem : ISystem
    {
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<TargetsBuffer>()
                .With<CollectTargetsInterval>()
                .With<CollectTargetsTimer>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                ref var collectTargetsTimer = ref entity.GetComponent<CollectTargetsTimer>();
                collectTargetsTimer.Value -= deltaTime;

                if (collectTargetsTimer.Value <= 0)
                {
                    entity.AddComponent<ReadyToCollectTargets>();
                    collectTargetsTimer.Value = entity.GetComponent<CollectTargetsInterval>().Value;
                }
            }
        }

        public void Dispose()
        {
        }
    }
}