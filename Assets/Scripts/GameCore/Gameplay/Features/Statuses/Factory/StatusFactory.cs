using System;
using GameCore.Gameplay.Features.Common.Extensions;
using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.Statuses.Components;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Statuses.Factory
{
    public class StatusFactory : IStatusFactory
    {
        public Entity Create(World world, StatusSetup statusSetup, EntityId producerId, EntityId targetId)
        {
            Entity status = world.CreateEntity();

            switch (statusSetup.StatusTypeId)
            {
                case StatusTypeId.Unknown:
                    break;

                case StatusTypeId.Poison:
                    status = CreatePoisonStatus(status, producerId, targetId);

                    break;

                case StatusTypeId.Freeze:
                    status = CreateFreezeStatus(status, producerId, targetId);

                    break;
                    //
                    // case StatusTypeId.PoisonEnchant:
                    //     status = CreatePoisonEnchantStatus(status, producerId, targetId);
                    //
                    //     break;
                    //
                    // case StatusTypeId.ExplosiveEnchant:
                    //     status = CreateExplosiveEnchantStatus(status, producerId, targetId);

                    // break;

                default:
                    throw new Exception($"Status with typeId {statusSetup.StatusTypeId} does not exist");
            }

            return status
                .With(x => x.SetComponent(new EffectValue {Value = statusSetup.Value}), when: statusSetup.Value != 0)
                .With(x => x.SetComponent(new Duration {Value = statusSetup.Duration}), when: statusSetup.Duration > 0)
                .With(x => x.SetComponent(new TimeLeft {Value = statusSetup.Duration}), when: statusSetup.Duration > 0)
                .With(x => x.SetComponent(new Period {Value = statusSetup.Period}), when: statusSetup.Period > 0)
                .With(x => x.SetComponent(new TimeSinceLastTick {Value = 0}), when: statusSetup.Period > 0)
                .With(x => x.AddComponent<StatusTag>());
        }

        private Entity CreatePoisonStatus(Entity status, EntityId producerId, EntityId targetId) =>
            status
                .With(x => x.SetComponent(new StatusTypeIdComponent {Value = StatusTypeId.Poison}))
                .With(x => x.SetComponent(new ProducerId {Value = producerId}))
                .With(x => x.SetComponent(new TargetId {Value = targetId}))
                .With(x => x.AddComponent<PoisonTag>());

        private Entity CreateFreezeStatus(Entity status, EntityId producerId, EntityId targetId) =>
            status
                .With(x => x.SetComponent(new StatusTypeIdComponent {Value = StatusTypeId.Freeze}))
                .With(x => x.SetComponent(new ProducerId {Value = producerId}))
                .With(x => x.SetComponent(new TargetId {Value = targetId}))
                .With(x => x.AddComponent<FreezeTag>());

        //     private Entity CreatePoisonEnchantStatus(Entity status, EntityId producerId, EntityId targetId) =>
        //         CreateEntity.Empty()
        //             .AddId(_identifierService.Next())
        //             .AddStatusTypeId(StatusTypeId.PoisonEnchant)
        //             .AddEnchantTypeId(EnchantTypeId.PoisonArmaments)
        //             .AddProducerId(producerId)
        //             .AddTargetId(targetId)
        //             .With(x => x.isPoisonEnchant = true);
        //
        //     private Entity CreateExplosiveEnchantStatus(Entity status, EntityId producerId, EntityId targetId) =>
        //         CreateEntity.Empty()
        //             .AddId(_identifierService.Next())
        //             .AddStatusTypeId(StatusTypeId.ExplosiveEnchant)
        //             .AddEnchantTypeId(EnchantTypeId.ExplosiveArmaments)
        //             .AddProducerId(producerId)
        //             .AddTargetId(targetId)
        //             .With(x => x.isExplosiveEnchant = true);
    }
}