using System.Linq;
using GameCore.Domain.Configs;
using GameCore.Domain.Enums;
using GameCore.Gameplay.Common.View.Registrars;
using GameCore.Gameplay.Features.Stats.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace GameCore.Gameplay.Features.Stats.Registrars
{
    public class StatsRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private BaseStatsConfig _statsConfig;

        public override void RegisterComponents(Entity gameEntity)
        {
            var stats = new StatsContainerValue
            {
                Base = new StatsContainer(),
                Current = new StatsContainer()
            };

            stats.Base.Set(
                BaseStatType.Speed,
                _statsConfig.BaseStats.First(x => x.Type == BaseStatType.Speed).Value);

            stats.Current.Set(
                BaseStatType.Speed,
                _statsConfig.BaseStats.First(x => x.Type == BaseStatType.Speed).Value);

            gameEntity.SetComponent(stats);
        }

        public override void UnregisterComponents(Entity gameEntity)
        {
            if (gameEntity.Has<StatsContainerValue>())
                gameEntity.RemoveComponent<StatsContainerValue>();
        }
    }
}