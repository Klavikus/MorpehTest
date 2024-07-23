using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using GameCore.Infrastructure.AssetManagement;
using Qw1nt.Runtime.AddressablesContentController.Common;
using Qw1nt.Runtime.AddressablesContentController.Core;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using UnityEngine.AddressableAssets;

namespace GameCore.Infrastructure
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly ContentController _contentController;

        private ConfigurationContainer _configurationContainer;
        private Dictionary<int, SceneData> _sceneDataById;
        
        public ConfigurationProvider(ContentController contentController)
        {
            _contentController = contentController;
        }

        public SceneData BootstrapSceneData => _configurationContainer.BootstrapSceneData;
        public SceneData MainMenuSceneData => _configurationContainer.MainMenuSceneData;
        public SceneData GameloopSceneData => _configurationContainer.GameloopSceneData;
        public string LocalizationTablePath => _configurationContainer.LocalizationTablePath;
        public AssetReference LoadingScreenViewReference => _configurationContainer.LoadingScreenViewReference;
        public AssetReference PlayerRegistrar  => _configurationContainer.PlayerRegistrar;
        public AssetReference EnemyRegistrar  => _configurationContainer.EnemyRegistrar;

        public SceneData GetLevelConfig(int selectedLevelId) =>
            _sceneDataById[selectedLevelId];

        public async UniTask Initialize()
        {
            ContentOperation<ConfigurationContainer> operation =
                await _contentController.LoadAsync<ConfigurationContainer>(
                    AssetKeys.KeyByType[typeof(ConfigurationContainer)]);

            _configurationContainer = operation.GetResult();
            _sceneDataById = Enumerable
                .Range(0, _configurationContainer.LevelsSceneData.Count())
                .ToDictionary(i => i, i => _configurationContainer.LevelsSceneData[i]);
        }
    }
}