using GameCore.Controllers.Services;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using Sources.Infrastructure.Api.Services.Providers;
using UnityEngine.SceneManagement;

namespace GameCore.Controllers.GameFSM.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly SceneManipulator _sceneLoader;
        private readonly ICurtainService _curtainService;
        private readonly IConfigurationProvider _configurationProvider;

        public BootstrapState(
            IGameStateMachine gameStateMachine,
            SceneManipulator sceneLoader,
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
            await _configurationProvider.Initialize();
            // await _sceneLoader.Load(_configurationProvider.BootstrapSceneData);
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