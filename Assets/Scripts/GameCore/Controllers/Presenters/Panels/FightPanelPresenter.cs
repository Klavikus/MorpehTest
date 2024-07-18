using GameCore.Controllers.Services;
using GameCore.Domain.Models;
using GameCore.Presentation.Abstract;
using GameCore.UseCases;

namespace GameCore.Controllers.Presenters.Panels
{
    public sealed class FightPanelPresenter : PanelPresenterBase
    {
        private readonly LevelLoadingService _levelLoadingService;
        private readonly GetLevelSelectionUseCase _getLevelSelectionUseCase;
        private readonly IFightPanelView _view;

        public FightPanelPresenter(
            LevelLoadingService levelLoadingService,
            GetLevelSelectionUseCase getLevelSelectionUseCase,
            IFightPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.FightPanel, view.Show, view.Hide)
        {
            _levelLoadingService = levelLoadingService;
            _getLevelSelectionUseCase = getLevelSelectionUseCase;
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