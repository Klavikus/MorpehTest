using GameCore.Controllers.Implementation.Services;
using GameCore.Domain.Enums;
using GameCore.Presentation.Abstract.Panels;

namespace GameCore.Controllers.Implementation.Presenters.Panels
{
    public sealed class FightPanelPresenter : PanelPresenterBase
    {
        private readonly LevelLoadingService _levelLoadingService;
        private readonly IFightPanelView _view;

        public FightPanelPresenter(
            LevelLoadingService levelLoadingService,
            IFightPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.FightPanel, view.Show, view.Hide)
        {
            _levelLoadingService = levelLoadingService;
            _view = view;
        }

        protected override void OnAfterEnable()
        {
            _view.StartButton.onClick.AddListener(StartLevel);
        }

        protected override void OnAfterDisable()
        {
            _view.StartButton.onClick.RemoveListener(StartLevel);
        }

        private void StartLevel()
        {
            _levelLoadingService.StartSelected();
        }
    }
}