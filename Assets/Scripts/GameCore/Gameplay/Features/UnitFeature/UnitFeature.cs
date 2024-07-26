using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.UnitFeature.Systems;

namespace GameCore.Gameplay.Features.UnitFeature
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