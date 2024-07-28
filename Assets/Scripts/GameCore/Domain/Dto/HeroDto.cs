using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameCore.Domain.Dto
{
    [Serializable]
    public class HeroDto
    {
        public int Id;
        public AssetReference Reference;
        public Sprite Avatar;
    }
}