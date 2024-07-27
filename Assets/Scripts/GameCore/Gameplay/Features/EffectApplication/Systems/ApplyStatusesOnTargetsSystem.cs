﻿using GameCore.Gameplay.Common;
using GameCore.Gameplay.Common.Extensions;
using GameCore.Gameplay.Features.Armaments.Components;
using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.Statuses;
using GameCore.Gameplay.Features.Statuses.Applier;
using GameCore.Gameplay.Features.Statuses.Components;
using GameCore.Gameplay.Features.TargetCollection.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using VContainer;

namespace GameCore.Gameplay.Features.EffectApplication.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class ApplyStatusesOnTargetsSystem : ISystem, IInjectable
    {
        private IStatusApplier _statusApplier;
        private Filter _entities;
        private Filter _possibleTargets;

        public World World { get; set; }

        public void Inject(IObjectResolver objectResolver)
        {
            _statusApplier = objectResolver.Resolve<IStatusApplier>();
        }

        public void OnAwake()
        {
            _entities = World.Filter
                .With<TargetsBufferValue>()
                .With<StatusSetupsValue>()
                .Build();

            _possibleTargets = World.Filter
                .With<StatusTypeIdValue>()
                .With<TargetIdValue>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _entities)
            foreach (EntityId targetId in entity.GetComponent<TargetsBufferValue>().Value)
            foreach (StatusSetup setup in entity.GetComponent<StatusSetupsValue>().Value)
            {
                _statusApplier
                    .Apply(World, _possibleTargets, setup, ProducerId(entity), targetId)
                    .With(x => x.AddComponent<Applied>());
            }
        }

        public void Dispose()
        {
        }

        private static EntityId ProducerId(Entity entity) =>
            entity.Has<ProducerIdValue>() ? entity.GetComponent<ProducerIdValue>().Value : entity.ID;
    }
}