using GameCore.Controllers.Implementation.GameFSM.States;
using Modules.Infrastructure.Interfaces.GameFsm;
using VContainer;
using VContainer.Unity;

namespace GameCore.Application
{
    internal class Game : IInitializable, ITickable
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IObjectResolver _objectResolver;

        public Game(IGameStateMachine gameStateMachine, IObjectResolver objectResolver)
        {
            _gameStateMachine = gameStateMachine;
            _objectResolver = objectResolver;
        }

        public void Initialize()
        {
            _gameStateMachine.RegisterState(_objectResolver.Resolve<BootstrapState>());
            _gameStateMachine.RegisterState(_objectResolver.Resolve<LoadDataState>());
            _gameStateMachine.RegisterState(_objectResolver.Resolve<MainMenuState>());
            _gameStateMachine.RegisterState(_objectResolver.Resolve<GameLoopState>());

            _gameStateMachine.Enter<BootstrapState>();
        }

        public void Tick()
        {
            _gameStateMachine.Update();
        }
    }
}