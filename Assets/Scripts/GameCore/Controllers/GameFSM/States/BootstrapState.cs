using GameCore.Controllers.Services;
using Modules.Infrastructure.Implementation;
using Modules.Infrastructure.Interfaces.GameFsm;
using Sources.Infrastructure.Api.Services.Providers;

namespace GameCore.Controllers.GameFSM.States
{
    public class BootstrapState : IState
    {
        private const string s_bootstrapScene = "Bootstrap";

        private readonly IGameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly ICurtainService _curtainService;
        private readonly IConfigurationProvider _configurationProvider;

        public BootstrapState(
            IGameStateMachine gameStateMachine,
            SceneLoader sceneLoader,
            ICurtainService curtainService,
            IConfigurationProvider configurationProvider)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtainService = curtainService;
            _configurationProvider = configurationProvider;
        }

        public async void Enter()
        {
            await _sceneLoader.LoadAsync(s_bootstrapScene);
            await _configurationProvider.Initialize();
            await _curtainService.Initialize();
            await _curtainService.Show();

            _gameStateMachine.Enter<LoadDataState>();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}