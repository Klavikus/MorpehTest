using System;
using GameCore.Domain.Configs.Setups;
using GameCore.Domain.Enums;
using GameCore.Gameplay.Features.Effects;
using GameCore.Gameplay.Features.Statuses;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameCore.Gameplay.Features.Abilities
{
    [Serializable]
    public class AbilityLevel
    {
        [field: SerializeField] public AbilityId AbilityId { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public string Description { get; private set; }

        [field: SerializeField] public AssetReference ViewPrefab { get; private set; }
        [field: SerializeField] public ProjectileSetup ProjectileSetup { get; private set; }
        [field: SerializeField] public EffectSetup[] EffectSetups { get; private set; }
        [field: SerializeField] public StatusSetup[] StatusSetups { get; private set; }
    }
}