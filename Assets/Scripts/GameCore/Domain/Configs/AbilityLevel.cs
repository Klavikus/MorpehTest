using System;
using GameCore.Domain.Enums;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameCore.Domain.Configs
{
    [Serializable]
    public class AbilityLevel
    {
        [field: SerializeField] public AbilityId AbilityId { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string Description { get; private set; }

        [field: SerializeField] public AssetReference ViewPrefab { get; private set; }
    }
}