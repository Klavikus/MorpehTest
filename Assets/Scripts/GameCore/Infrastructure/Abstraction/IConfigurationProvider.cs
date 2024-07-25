using GameCore.Gameplay.Features.AbilitiesFeature;
using GameCore.Gameplay.Features.AbilitiesFeature.Configs;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using UnityEngine.AddressableAssets;

namespace GameCore.Infrastructure.Abstraction
{
    public interface IConfigurationProvider : IAsyncInitializable
    {
        SceneData BootstrapSceneData { get; }
        SceneData MainMenuSceneData { get; }
        SceneData GameloopSceneData { get; }
        string LocalizationTablePath { get; }
        AssetReference LoadingScreenViewReference { get; }
        AssetReference PlayerRegistrar { get; }
        AssetReference EnemyRegistrar { get; }
        SceneData GetLevelConfig(int selectedLevelId);
        AbilityLevel GetAbilityLevel(AbilityId fireBolt, int level);
    }
}