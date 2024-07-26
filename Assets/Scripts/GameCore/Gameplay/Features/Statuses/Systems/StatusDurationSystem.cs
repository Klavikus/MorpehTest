using GameCore.Gameplay.Features.Statuses.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.Statuses.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class StatusDurationSystem : ISystem
    {
        private Filter _statuses;

        public World World { get; set; }

        public void OnAwake()
        {
            _statuses = World.Filter
                .With<Duration>()
                .With<StatusTag>()
                .With<TimeLeft>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity status in _statuses)
            {
                if (status.GetComponent<TimeLeft>().Value >= 0)
                {
                    ref var timeLeft = ref status.GetComponent<TimeLeft>();
                    timeLeft.Value -= deltaTime;
                }
                else
                {
                    status.AddComponent<UnappliedTag>();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}