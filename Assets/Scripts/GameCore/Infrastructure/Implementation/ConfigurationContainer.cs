using GameCore.Domain.Dto;
using GameCore.Gameplay.Features.Abilities;
using GameCore.Presentation.Implementation;
using GameCore.Presentation.Implementation.HeroSelection;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameCore.Infrastructure.Implementation
{
    [CreateAssetMenu(menuName = "Data/Create ConfigurationContainer", fileName = "ConfigurationContainer", order = 0)]
    public class ConfigurationContainer : ScriptableObject
    {
        [field: SerializeField] public SceneData BootstrapSceneData { get; private set; }
        [field: SerializeField] public SceneData MainMenuSceneData { get; private set; }
        [field: SerializeField] public SceneData GameloopSceneData { get; private set; }
        [field: SerializeField] public string LocalizationTablePath { get; private set; }
        [field: SerializeField] public AssetReference LoadingScreenViewReference { get; private set; }
        [field: SerializeField] public SceneData[] LevelsSceneData { get; private set; }
        [field: SerializeField] public AssetReference PlayerRegistrar { get; private set; }
        [field: SerializeField] public AssetReference EnemyRegistrar { get; private set; }
        [field: SerializeField] public HeroSelector HeroSelectorPrefab { get; private set; }
        [field: SerializeField] public AbilityLevel[] AbilityLevels { get; private set; }
        [field: SerializeField] public HeroDto[] HeroData { get; private set; }
    }
}