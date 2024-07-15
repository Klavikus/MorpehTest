using System;
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

        public ConfigurationProvider(ContentController contentController)
        {
            _contentController = contentController;
        }

        public SceneData BootstrapSceneData => _configurationContainer.BootstrapSceneData;
        public SceneData MainMenuSceneData => _configurationContainer.MainMenuSceneData;
        public SceneData GameloopSceneData => _configurationContainer.GameloopSceneData;
        public string LocalizationTablePath => _configurationContainer.LocalizationTablePath;
        public AssetReference LoadingScreenViewReference => _configurationContainer.LoadingScreenViewReference;

        public async UniTask Initialize()
        {
            ContentOperation<ConfigurationContainer> operation =
                await _contentController.LoadAsync<ConfigurationContainer>(
                    AssetKeys.KeyByType[typeof(ConfigurationContainer)]);

            _configurationContainer = operation.GetResult();
        }

        public async UniTask Initialize(IProgress<float> progress)
        {
            progress.Report(0);
            ContentOperation<ConfigurationContainer> operation =
                await _contentController.LoadAsync<ConfigurationContainer>(
                    AssetKeys.KeyByType[typeof(ConfigurationContainer)]);
            progress.Report(1f);

            _configurationContainer = operation.GetResult();
        }
    }
}