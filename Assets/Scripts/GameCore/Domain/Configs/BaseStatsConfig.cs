using System;
using System.Collections.Generic;
using System.Linq;
using GameCore.Domain.Enums;
using UnityEngine;

namespace GameCore.Domain.Configs
{
    [CreateAssetMenu(menuName = "Data/Create BaseStatsConfig", fileName = "BaseStatsConfig", order = 0)]
    public class BaseStatsConfig : ScriptableObject
    {
        public BaseStatsConfig()
        {
            BaseStats = Enum
                .GetValues(typeof(BaseStatType))
                .Cast<int>()
                .Select(x => new BaseStat() {Type = (BaseStatType) x, Value = 0})
                .ToList();
        }

        [field: SerializeField] public List<BaseStat> BaseStats { get; private set; }
    }

    [Serializable]
    public struct BaseStat
    {
        public BaseStatType Type;
        public float Value;
    }
}