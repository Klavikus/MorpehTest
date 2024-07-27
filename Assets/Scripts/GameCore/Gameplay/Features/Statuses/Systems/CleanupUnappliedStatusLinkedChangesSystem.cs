using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.Statuses.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Statuses.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CleanupUnappliedStatusLinkedChangesSystem : ICleanupSystem
    {
        private Filter _statuses;
        private Filter _entities;

        public World World { get; set; }

        public void OnAwake()
        {
            _statuses = World.Filter
                .With<Status>()
                .With<Unapplied>()
                .Build();

            _entities = World.Filter
                .With<ApplierStatusLinkValue>()
                .Without<Destructed>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity status in _statuses)
            foreach (Entity entity in _entities)
            {
                if (entity.GetComponent<ApplierStatusLinkValue>().Value == status.ID)
                    entity.AddComponent<Destructed>();
            }
        }

        public void Dispose()
        {
        }
    }
}