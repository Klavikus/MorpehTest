using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CleanupTargetBuffersSystem : ICleanupSystem
    {
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<TargetsBuffer>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                entity.GetComponent<TargetsBuffer>().Value.Clear();
            }
        }

        public void Dispose()
        {
        }
    }
}