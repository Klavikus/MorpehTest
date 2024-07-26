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
                .With<StatusTag>()
                .With<UnappliedTag>()
                .Build();

            _entities = World.Filter
                .With<ApplierStatusLink>()
                .Without<DestructedTag>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity status in _statuses)
            foreach (Entity entity in _entities)
            {
                if (entity.GetComponent<ApplierStatusLink>().Value == status.ID)
                    entity.AddComponent<DestructedTag>();
            }
        }

        public void Dispose()
        {
        }
    }
}