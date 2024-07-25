using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.AbilitiesFeature.Armaments.Factory
{
    public interface IArmamentsFactory
    {
        Entity CreateFireBolt(int level, Vector3 at, Entity entity);
    }
}