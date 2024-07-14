using Cysharp.Threading.Tasks;
using GameCore.Infrastructure.AssetManagement;
using Qw1nt.Runtime.AddressablesContentController.Common;
using Qw1nt.Runtime.AddressablesContentController.Core;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using Sources.Infrastructure.Api.Services.Providers;

namespace Sources.Infrastructure.Core.Services.Providers
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

        public async UniTask Initialize()
        {
            ContentOperation<ConfigurationContainer> operation =
                await _contentController.LoadAsync<ConfigurationContainer>(
                    AssetKeys.KeyByType[typeof(ConfigurationContainer)]);
          
            _configurationContainer = operation.GetResult();
        }
    }
}