using Modules.Infrastructure.Interfaces.GameFsm;

namespace GameCore.Controllers.GameFSM.States
{
    public class LoadDataState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public LoadDataState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            _gameStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}