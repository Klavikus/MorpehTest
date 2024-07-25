using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class MarkReachedSystem : ISystem
    {
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<TargetsBuffer>()
                .Without<Reached>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            {
                if (entity.GetComponent<TargetsBuffer>().Value.Count > 0)
                    entity.AddComponent<Reached>();
            }
        }

        public void Dispose()
        {
        }
    }
}