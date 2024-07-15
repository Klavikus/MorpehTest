using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using UnityEngine.AddressableAssets;

namespace GameCore.Infrastructure
{
    public interface IConfigurationProvider : IAsyncInitializable
    {
        SceneData BootstrapSceneData { get; }
        SceneData MainMenuSceneData { get; }
        SceneData GameloopSceneData { get; }
        string LocalizationTablePath { get; }
        AssetReference LoadingScreenViewReference { get; }
    }
}