using GameCore.Domain.Common;
using UnityEngine;

namespace GameCore.Domain.Configs
{
    [CreateAssetMenu(menuName = "Data/Create GameplaySceneConfig", fileName = "GameplaySceneConfig", order = 0)]
    public class GameplaySceneConfig : ScriptableObject
    {
        [field: SerializeField] public Point StartPoint { get; private set; }
        [field: SerializeField] public Point EnemyPoint { get; private set; }
    }
}