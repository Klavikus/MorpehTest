using GameCore.Controllers.Implementation.GameFSM.States;
using GameCore.Presentation.Implementation.Gameplay;
using Modules.Infrastructure.Interfaces.GameFsm;
using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace GameCore.Controllers.Implementation.Presenters.Gameplay
{
    public class GameplayPresenter : IPresenter
    {
        private readonly GameplayMainView _view;
        private readonly IGameStateMachine _gameStateMachine;

        public GameplayPresenter(GameplayMainView view, IGameStateMachine gameStateMachine)
        {
            _view = view;
            _gameStateMachine = gameStateMachine;
        }

        public void Enable()
        {
            _view.BackToMenuButton.onClick.AddListener(_gameStateMachine.Enter<MainMenuState>);
        }

        public void Disable()
        {
            _view.BackToMenuButton.onClick.RemoveListener(_gameStateMachine.Enter<MainMenuState>);
        }
    }
}