using System.Collections.Generic;
using GameCore.Domain.Configs;
using GameCore.Domain.Configs.Setups;
using GameCore.Domain.Enums;
using GameCore.Gameplay.Common.Components;
using GameCore.Gameplay.Features.AbilitiesFeature.Armaments.Components;
using GameCore.Gameplay.Features.Common.Components;
using GameCore.Gameplay.Features.Common.Extensions;
using GameCore.Gameplay.Features.MovingFeature.Components;
using GameCore.Gameplay.Features.TargetCollection.Components;
using GameCore.Gameplay.Features.ViewFeature.Components;
using GameCore.Infrastructure.Abstraction;
using Scellecs.Morpeh;
using UnityEngine;
using LayerMask = GameCore.Gameplay.Features.TargetCollection.Components.LayerMask;

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
            ProjectileSetup setup = abilityLevel.ProjectileSetup;

            entity.SetComponent(new ViewPathComponent {Path = abilityLevel.ViewPrefab.AssetGUID});
            entity.SetComponent(new SelfDestructTimer {Value = setup.Lifetime});
            entity.SetComponent(new MoveSpeedComponent {Value = setup.Speed});
            entity.SetComponent(new Radius {Value = setup.ContactRadius});
            entity.SetComponent(new TargetsBuffer {Value = new List<EntityId>(16)});
            entity.SetComponent(new ProcessedTargetsBuffer {Value = new List<EntityId>(16)});
            entity.SetComponent(new LayerMask {Value = CollisionLayer.Enemy.AsMask()});
            entity.SetComponent(new ReadyToCollectTargets());
            entity.SetComponent(new CollectingTargetsContinuously());
            entity.SetComponent(new WorldPosition {Value = at});
            entity.AddComponent<ArmamentTag>();
            entity.AddComponent<CreateRequest>();

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