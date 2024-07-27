using System.Collections.Generic;
using System.Linq;
using GameCore.Gameplay.Common;
using GameCore.Gameplay.Common.Physic;
using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.Lifetime.Components;
using GameCore.Gameplay.Features.TargetCollection.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.TargetCollection.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CastForTargetsNoLimitSystem : ISystem, IInjectable
    {
        private IPhysicsService _physicsService;
        private Filter _ready;

        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _physicsService = objectResolver.Resolve<IPhysicsService>();
        }

        public void OnAwake()
        {
            _ready = World.Filter
                .With<ReadyToCollectTargets>()
                .With<TargetsBufferValue>()
                .With<TransformValue>()
                .With<RadiusValue>()
                .With<LayerMaskValue>()
                .Without<TargetLimitValue>()
                .Build();
        }

        public void Dispose()
        {
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _ready)
            {
                ref var targetsBuffer = ref entity.GetComponent<TargetsBufferValue>();
                targetsBuffer.Value.AddRange(TargetsInRadius(entity));

                if (entity.Has<CollectingTargetsContinuously>() == false)
                    entity.RemoveComponent<ReadyToCollectTargets>();
            }
        }

        private IEnumerable<EntityId> TargetsInRadius(Entity entity) =>
            _physicsService
                .CircleCast(
                    entity.GetComponent<TransformValue>().Value.position,
                    entity.GetComponent<RadiusValue>().Value,
                    entity.GetComponent<LayerMaskValue>().Value)
                .Where(x => x.Has<Dead>() == false)
                .Select(x => x.ID);
    }
}