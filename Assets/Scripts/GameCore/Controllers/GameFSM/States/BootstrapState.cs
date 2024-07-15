using GameCore.Infrastructure;
using GameCore.Infrastructure.Factories;
using Modules.Infrastructure.Interfaces.GameFsm;

namespace GameCore.Controllers.GameFSM.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ILoadingScreenFactory _loadingScreenFactory;

        public BootstrapState(
            IGameStateMachine gameStateMachine,
            IConfigurationProvider configurationProvider,
            ILoadingScreenFactory loadingScreenFactory)
        {
            _gameStateMachine = gameStateMachine;
            _configurationProvider = configurationProvider;
            _loadingScreenFactory = loadingScreenFactory;
        }

        public async void Enter()
        {
            await _configurationProvider.Initialize();
            await _loadingScreenFactory.Create();

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