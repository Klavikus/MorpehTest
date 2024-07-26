using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Common.Extensions;
using GameCore.Gameplay.Features.Effects.Components;
using GameCore.Gameplay.Features.Statuses.Components;
using GameCore.Gameplay.Features.Statuses.Factory;
using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Statuses.Applier
{
    public class StatusApplier : IStatusApplier
    {
        private readonly IStatusFactory _statusFactory;

        public StatusApplier(IStatusFactory statusFactory)
        {
            _statusFactory = statusFactory;
        }

        public Entity Apply(World world, Filter possibleStatuses, StatusSetup statusSetup, EntityId producerId,
            EntityId targetId)
        {
            // world.Filter
            //     .With<StatusTypeIdComponent>()
            //     .With<TargetId>()
            //     .Build();

            foreach (Entity possibleStatus in possibleStatuses)
            {
                if (possibleStatus.GetComponent<StatusTypeIdComponent>().Value != statusSetup.StatusTypeId ||
                    possibleStatus.GetComponent<TargetId>().Value != targetId)
                    continue;

                ref var timeLeft = ref possibleStatus.GetOrAdd<TimeLeft>();
                timeLeft.Value = statusSetup.Duration;

                return possibleStatus;
            }

            return _statusFactory.Create(world, statusSetup, producerId, targetId)
                .With(x => x.AddComponent<AppliedTag>());
        }
    }
}