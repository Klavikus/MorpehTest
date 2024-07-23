using System.Collections.Generic;
using GameCore.Domain.Enums;
using GameCore.Extensions;

namespace GameCore.Gameplay.Features.Stats
{
    public class StatsContainer
    {
        private readonly Dictionary<BaseStatType, float> _statByType;

        public StatsContainer()
        {
            _statByType = EnumExtensions.ToDictionary<BaseStatType, float>(0, 1);
        }

        public float Get(BaseStatType statType)
        {
            return _statByType[statType];
        }

        public void Set(BaseStatType statType, float value)
        {
            _statByType[statType] = value;
        }
    }
}