using GameCore.Gameplay.Common;
using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.Lifetime.Components;
using GameCore.Gameplay.Features.UnitFeature.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace GameCore.Gameplay.Features.UnitFeature.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class UnitDeathSystem : ISystem
    {
        private const float DeathAnimationTimer = 2;

        private Filter _enemies;

        public World World { get; set; }

        public void OnAwake()
        {
            _enemies = World.Filter
                .With<UnitTag>()
                .With<DeadTag>()
                .With<ProcessingDeathTag>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (Entity enemy in _enemies)
            {
                // enemy.RemoveTargetCollectionComponents();

                // if (enemy.hasEnemyAnimator)
                // enemy.EnemyAnimator.PlayDied();

                enemy.RemoveComponent<ProcessingDeathTag>();
                ref var selfDestructTimer = ref enemy.GetOrAdd<SelfDestructTimer>();
                selfDestructTimer.Value = DeathAnimationTimer;
            }
        }

        public void Dispose()
        {
        }
    }
}