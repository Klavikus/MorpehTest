using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.Statuses.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Statuses.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CleanupUnappliedStatusesSystem : ICleanupSystem
    {
        private Filter _statuses;

        public World World { get; set; }

        public void OnAwake()
        {
            _statuses = World.Filter
                .With<StatusTag>()
                .With<UnappliedTag>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity status in _statuses) 
                status.AddComponent<DestructedTag>();
        }

        public void Dispose()
        {
        }
    }
}