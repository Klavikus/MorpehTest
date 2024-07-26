using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Statuses.Factory
{
    public interface IStatusFactory
    {
        Entity Create(World world, StatusSetup statusSetup, EntityId producerId, EntityId targetId);
    }
}