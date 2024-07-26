using Scellecs.Morpeh;

namespace GameCore.Gameplay.Features.Effects.Factory
{
    public interface IEffectFactory
    {
        Entity Create(World world, EffectSetup setup, EntityId producerId, EntityId targetId);
    }
}