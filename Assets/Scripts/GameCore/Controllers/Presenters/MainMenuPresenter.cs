using GameCore.Controllers.GameFSM.States;
using GameCore.Domain.Windows;
using GameCore.Infrastructure.AssetManagement;
using GameCore.Presentation.Abstract;
using GameCore.Presentation.Implementation.Components;
using Modules.Infrastructure.Interfaces.GameFsm;
using Modules.UI.MVPPassiveView.Runtime.Presenters;
using Modules.UI.WindowFsm.Runtime.Abstract;
using UnityEngine;

namespace GameCore.Controllers.Presenters
{
    public class MainMenuPresenter : BaseWindowPresenter<MainMenuWindow>
    {
        private readonly IMainMenuView _view;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IResourceService _resourceService;

        public MainMenuPresenter(
            IMainMenuView view,
            IGameStateMachine gameStateMachine,
            IResourceService resourceService,
            IWindowFsm windowFsm)
            : base(windowFsm, view.Show, view.Hide)
        {
            _view = view;
            _gameStateMachine = gameStateMachine;
            _resourceService = resourceService;
        }

        protected override void OnAfterEnable()
        {
            _view.Initialize();
            _view.ToGameloop.onClick.AddListener(Call);
        }

        protected override void OnAfterDisable()
        {
            _view.ToGameloop.onClick.RemoveAllListeners();
        }

        private void Call()
        {
            // _gameStateMachine.Enter<GameLoopState>();
        }
    }
}