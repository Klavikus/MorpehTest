using GameCore.Domain.Configs;
using GameCore.Domain.Enums;
using GameCore.Gameplay.Features.AbilitiesFeature.Armaments.Components;
using GameCore.Gameplay.Features.ViewFeature.Components;
using GameCore.Infrastructure.Abstraction;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.AbilitiesFeature.Armaments.Factory
{
    public class ArmamentsFactory : IArmamentsFactory
    {
        private readonly IConfigurationProvider _configurationProvider;

        public ArmamentsFactory(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public Entity CreateFireBolt(int level, Vector3 at, Entity entity)
        {
            AbilityLevel abilityLevel = _configurationProvider.GetAbilityLevel(AbilityId.FireBolt, level);
            // ProjectileSetup setup = abilityLevel.ProjectileSetup;

            entity.SetComponent(new ViewPathComponent {Path = abilityLevel.ViewPrefab.AssetGUID});
            entity.AddComponent<ArmamentTag>();

            // entity.AddComponent<>()

            return entity;
        }

        // private Entity CreateProjectileEntity(AbilityLevel abilityLevel, Vector3 at, ProjectileSetup setup) =>
        //     CreateEntity.Empty()
        //         .AddId(_identifierService.Next())
        //         .AddWorldPosition(at)
        //         .AddSpeed(setup.Speed)
        //         .AddRadius(setup.ContactRadius)
        //         .AddViewPrefab(abilityLevel.ViewPrefab)
        //         .With(x => x.AddEffectSetups(abilityLevel.EffectSetups.ToList()),
        //             when: !abilityLevel.EffectSetups.IsNullOrEmpty())
        //         .With(x => x.AddStatusSetups(abilityLevel.StatusSetups.ToList()),
        //             when: !abilityLevel.StatusSetups.IsNullOrEmpty())
        //         .AddTargetsBuffer(new List<int>(16))
        //         .AddProcessedTargetsBuffer(new List<int>(16))
        //         .AddLayerMask(CollisionLayer.Enemy.AsMask())
        //         .With(x => x.AddTargetLimit(setup.Pierce), when: setup.Pierce > 0)
        //         .With(x => x.isArmament = true)
        //         .With(x => x.isMovingAvailable = true)
        //         .With(x => x.isReadyToCollectTargets = true)
        //         .With(x => x.isCollectingTargetsContinuously = true);
    }
}