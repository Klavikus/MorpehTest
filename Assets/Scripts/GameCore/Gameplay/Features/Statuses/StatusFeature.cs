using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Statuses.Systems;

namespace GameCore.Gameplay.Features.Statuses
{
    public sealed class StatusFeature : Feature
    {
        public StatusFeature()
        {
            AddSystem<StatusDurationSystem>();
            AddSystem<PeriodicDamageStatusSystem>();
            AddSystem<ApplyFreezeStatusSystem>();
            AddCleanupSystem<CleanupUnappliedStatusLinkedChangesSystem>();
            AddCleanupSystem<CleanupUnappliedStatusesSystem>();

            // Add(systems.Create<StatusVisualsFeature>());
            // Add(systems.Create<RemoveUnappliedEnchantsFromHolder>());
        }
    }
}