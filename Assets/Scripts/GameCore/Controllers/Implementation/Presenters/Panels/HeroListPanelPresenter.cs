using GameCore.Controllers.Implementation.Services;
using GameCore.Domain.Dto;
using GameCore.Domain.Enums;
using GameCore.Infrastructure.Implementation.Factories;
using GameCore.Presentation.Abstract.Panels;

namespace GameCore.Controllers.Implementation.Presenters.Panels
{
    public sealed class HeroListPanelPresenter : PanelPresenterBase
    {
        private readonly IHeroSelectionService _heroSelectionService;
        private readonly IViewFactory _viewFactory;
        private readonly IHeroListPanelView _view;

        public HeroListPanelPresenter(
            IHeroSelectionService heroSelectionService,
            IViewFactory viewFactory,
            IHeroListPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.HeroListPanel, view.Show, view.Hide)
        {
            _heroSelectionService = heroSelectionService;
            _viewFactory = viewFactory;
            _view = view;
        }

        protected override void OnAfterEnable()
        {
            _viewFactory.CreateHeroButtons(_view.HeroSelectorContainer);
            _view.CloseButton.onClick.AddListener(WindowFsm.CloseCurrentWindow);

            _heroSelectionService.Focused += OnHeroFocused;
        }

        protected override void OnAfterDisable()
        {
            _view.CloseButton.onClick.RemoveListener(WindowFsm.CloseCurrentWindow);
        }

        private void OnHeroFocused(HeroDto heroDto)
        {
            _viewFactory.CreateHeroModelView(heroDto, _view.HeroModelContainer);
        }
    }
}