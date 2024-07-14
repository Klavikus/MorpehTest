using Cysharp.Threading.Tasks;
using GameCore.Infrastructure.AssetManagement;
using Sources.Infrastructure.Api.Services.Providers;

namespace Sources.Infrastructure.Core.Services.Providers
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IResourceService _resourceService;

        private ConfigurationContainer _configurationContainer;

        public ConfigurationProvider(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        public string BootstrapSceneName => _configurationContainer.BootstrapSceneName;
        public string MainMenuSceneName => _configurationContainer.MainMenuSceneName;
        public string GameloopSceneName => _configurationContainer.GameloopSceneName;
        public string LocalizationTablePath => _configurationContainer.LocalizationTablePath;

        public async UniTask Initialize()
        {
            _configurationContainer = await _resourceService.LoadAsync<ConfigurationContainer>(
                AssetKeys.KeyByType[typeof(ConfigurationContainer)]);
        }
    }
}