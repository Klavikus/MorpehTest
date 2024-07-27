using System.Collections.Generic;
using System.Linq;
using GameCore.Domain.Configs.Setups;
using GameCore.Domain.Enums;
using GameCore.Gameplay.Common.Components;
using GameCore.Gameplay.Features.AbilitiesFeature;
using GameCore.Gameplay.Features.Armaments.Components;
using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.Common.Extensions;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.TargetCollection.Components;
using GameCore.Gameplay.Features.ViewFeature.Components;
using GameCore.Infrastructure.Abstraction;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.Armaments.Factory
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
            AbilityLevel abilityLevel =
                (AbilityLevel) _configurationProvider.GetAbilityLevel(AbilityId.FireBolt, level);
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            entity.SetComponent(new ViewPathValue {Value = abilityLevel.ViewPrefab.AssetGUID});
            entity.SetComponent(new SelfDestructTimerValue {Value = setup.Lifetime});
            entity.SetComponent(new MoveSpeedValue {Value = setup.Speed});
            entity.SetComponent(new RadiusValue {Value = setup.ContactRadius});
            entity.SetComponent(new TargetsBufferValue {Value = new List<EntityId>(16)});
            entity.SetComponent(new ProcessedTargetsBufferValue {Value = new List<EntityId>(16)});
            entity.SetComponent(new LayerMaskValue {Value = CollisionLayer.Enemy.AsMask()});
            entity.SetComponent(new ReadyToCollectTargets());
            entity.SetComponent(new CollectingTargetsContinuously());
            entity.SetComponent(new WorldPositionValue {Value = at});
            entity.AddComponent<Armament>();
            entity.AddComponent<CreateRequest>();

            entity
                .With(
                    x => x.SetComponent(new EffectSetupsValue {Value = abilityLevel.EffectSetups.ToList()}),
                    when: !abilityLevel.EffectSetups.IsNullOrEmpty())
                .With(
                    x => x.SetComponent(new StatusSetupsValue {Value = abilityLevel.StatusSetups.ToList()}),
                    when: !abilityLevel.StatusSetups.IsNullOrEmpty());

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