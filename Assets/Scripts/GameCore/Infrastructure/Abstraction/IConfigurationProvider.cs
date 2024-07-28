using System.Collections;
using GameCore.Domain.Configs;
using GameCore.Domain.Dto;
using GameCore.Domain.Enums;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using UnityEngine;
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
        GameObject HeroSelector { get; }
        HeroDto[] HeroData { get; }
        SceneData GetLevelConfig(int selectedLevelId);
        object GetAbilityLevel(AbilityId abilityId, int level);
    }
}