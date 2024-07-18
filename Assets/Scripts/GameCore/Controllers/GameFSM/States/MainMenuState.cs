using GameCore.Controllers.Services.Loading;
using GameCore.Infrastructure;
using Modules.Infrastructure.Interfaces.GameFsm;
using VContainer;

namespace GameCore.Controllers.GameFSM.States
{
    public class MainMenuState : IState
    {
        private readonly ILoadingService _loadingService;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IObjectResolver _objectResolver;

        public MainMenuState(
            ILoadingService loadingService,
            IConfigurationProvider configurationProvider,
            IObjectResolver objectResolver)
        {
            _loadingService = loadingService;
            _configurationProvider = configurationProvider;
            _objectResolver = objectResolver;
        }

        public void Enter()
        {
            _loadingService.LoadScene(_configurationProvider.MainMenuSceneData, _objectResolver);
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}