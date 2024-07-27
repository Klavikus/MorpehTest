﻿using System;
using GameCore.Gameplay.Common;
using GameCore.Gameplay.Common.Physic;
using GameCore.Gameplay.Common.View.Components;
using GameCore.Gameplay.Features.TargetCollection.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.TargetCollection.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CastForTargetsWithLimitSystem : ISystem, IInjectable
    {
        private IPhysicsService _physicsService;
        private Filter _ready;

        private Entity[] _targetCastBuffer = new Entity[128];

        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _physicsService = objectResolver.Resolve<IPhysicsService>();
        }

        public void OnAwake()
        {
            _ready = World.Filter
                .With<ReadyToCollectTargets>()
                .With<TargetLimitValue>()
                .With<TargetsBufferValue>()
                .With<ProcessedTargetsBufferValue>()
                .With<TransformValue>()
                .With<RadiusValue>()
                .With<LayerMaskValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _ready)
            {
                for (int i = 0;
                     i < Math.Min(TargetCountInRadius(entity), entity.GetComponent<TargetLimitValue>().Value);
                     i++)
                {
                    EntityId targetId = _targetCastBuffer[i].ID;

                    if (AlreadyProcessed(entity, targetId) == false)
                    {
                        entity.GetComponent<TargetsBufferValue>().Value.Add(targetId);
                        entity.GetComponent<ProcessedTargetsBufferValue>().Value.Add(targetId);
                    }
                }

                if (entity.Has<CollectingTargetsContinuously>() == false)
                    entity.RemoveComponent<ReadyToCollectTargets>();
            }
        }

        public void Dispose()
        {
            _targetCastBuffer = null;
        }

        private int TargetCountInRadius(Entity entity) =>
            _physicsService
                .CircleCastNonAlloc(
                    entity.GetComponent<TransformValue>().Value.position,
                    entity.GetComponent<RadiusValue>().Value,
                    entity.GetComponent<LayerMaskValue>().Value,
                    _targetCastBuffer);

        private bool AlreadyProcessed(Entity entity, EntityId targetId) =>
            entity.GetComponent<ProcessedTargetsBufferValue>().Value.Contains(targetId);
    }
}