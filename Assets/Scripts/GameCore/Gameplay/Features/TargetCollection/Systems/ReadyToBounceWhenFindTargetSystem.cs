using System.Linq;
using GameCore.Gameplay.Features.AbilitiesFeature.Components;
using GameCore.Gameplay.Features.TargetCollection.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.TargetCollection.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ReadyToBounceWhenFindTargetSystem : ISystem
    {
        private Filter _bouncer;

        public World World { get; set; }

        public void OnAwake()
        {
            _bouncer = World.Filter
                .With<BounceValue>()
                .With<TargetsBufferValue>()
                .With<PreviousTargetValue>()
                .Without<ReadyToBounce>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity bouncer in _bouncer)
            {
                if (bouncer.GetComponent<TargetsBufferValue>().Value.Count > 0)
                {
                    bouncer.AddComponent<ReadyToBounce>();
                    ref var previousTarget = ref bouncer.GetComponent<PreviousTargetValue>();
                    previousTarget.Value = bouncer.GetComponent<TargetsBufferValue>().Value.Last();
                }
            }
        }

        public void Dispose()
        {
        }
    }
}