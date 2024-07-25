using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameCore.Gameplay.Features.AbilitiesFeature.Configs
{
    [Serializable]
    public class AbilityLevel
    {
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string Description { get; private set; }

        [field: SerializeField] public AssetReference ViewPrefab { get; private set; }
    }
}