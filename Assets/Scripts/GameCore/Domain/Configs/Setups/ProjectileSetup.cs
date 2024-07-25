using System;
using UnityEngine;

namespace GameCore.Domain.Configs.Setups
{
    [Serializable]
    public class ProjectileSetup
    {
        [field: SerializeField] public float Speed { get; private set; } = 1;
        [field: SerializeField] public int Pierce { get; private set; } = 1;
        [field: SerializeField] public float ContactRadius { get; private set; } = 0.1f;
        [field: SerializeField] public float Lifetime { get; private set; } = 3;
        [field: SerializeField] public int Amount { get; private set; } = 1;
        [field: SerializeField] public int MaxBounceAmount { get; private set; } = 0;
        
        [field: SerializeField] public int ProjectileCount { get; private set; } = 1;
        [field: SerializeField] public int OrbitRadius { get; private set; } = 0;
    }
}