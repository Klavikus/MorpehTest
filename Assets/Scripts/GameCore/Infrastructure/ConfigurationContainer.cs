using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace GameCore.Infrastructure
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
    }
}