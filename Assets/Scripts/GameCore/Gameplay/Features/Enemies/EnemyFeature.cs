using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Units.Systems;

namespace GameCore.Gameplay.Features.Enemies
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature()
        {
            AddInitializer<EnemyUnitInitSystem>();
            AddSystem<ChaseTargetSetterSystem>();
        }
    }
}