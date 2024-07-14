using GameCore.Controllers.GameFSM.States;
using GameCore.Domain.Windows;
using GameCore.Presentation.Abstract;
using Modules.Infrastructure.Interfaces.GameFsm;
using Modules.UI.MVPPassiveView.Runtime.Presenters;
using Modules.UI.WindowFsm.Runtime.Abstract;

namespace GameCore.Controllers.Presenters
{
    public class GameloopPresenter : BaseWindowPresenter<GameloopWindow>
    {
        private readonly IGameloopView _gameloopView;
        private readonly IGameStateMachine _gameStateMachine;

        public GameloopPresenter(
            IGameloopView gameloopView,
            IGameStateMachine gameStateMachine,
            IWindowFsm windowFsm)
            : base(windowFsm, gameloopView.Show, gameloopView.Hide)
        {
            _gameloopView = gameloopView;
            _gameStateMachine = gameStateMachine;
        }

        protected override void OnAfterEnable()
        {
            _gameloopView.ToMainMenu.onClick.AddListener(Call);
        }

        protected override void OnAfterDisable()
        {
            _gameloopView.ToMainMenu.onClick.RemoveAllListeners();
        }

        private void Call()
        {
            _gameStateMachine.Enter<MainMenuState>();
        }
    }
}