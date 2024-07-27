using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Units.Systems;

namespace GameCore.Gameplay.Features.Units
{
    public class UnitFeature : Feature
    {
        public UnitFeature()
        {
            AddInitializer<EnemyUnitInitSystem>();
            AddSystem<ChaseTargetSetterSystem>();
            AddSystem<ChaseTargetSystem>();
            AddSystem<UnitDeathSystem>();
            AddSystem<ChaseCleanupSystem>();
        }
    }
}