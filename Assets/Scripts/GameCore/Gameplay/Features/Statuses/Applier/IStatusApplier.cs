using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Statuses.Applier
{
    public interface IStatusApplier
    {
        Entity Apply(
            World world,
            Filter possibleStatuses,
            StatusSetup statusSetup,
            EntityId producerId,
            EntityId targetId);
    }
}