using System.Linq;
using GameCore.Controllers.Abstracion.Services;
using GameCore.Controllers.Implementation.UseCases.HeroSelection;
using GameCore.Controllers.Implementation.UseCases.Progress;
using GameCore.Domain.Dto;
using GameCore.Domain.Enums;
using GameCore.Infrastructure.Abstraction;
using GameCore.Infrastructure.Abstraction.Factories;
using GameCore.Presentation.Abstract.Panels;

namespace GameCore.Controllers.Implementation.Presenters.Panels
{
    public sealed class HeroListPanelPresenter : PanelPresenterBase
    {
        private readonly GetSelectedHeroIdUseCase _getSelectedHeroIdUseCase;
        private readonly SetSelectedHeroIdUseCase _setSelectedHeroIdUseCase;
        private readonly SaveProgressToLocalUseCase _saveProgressToLocalUseCase;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IHeroSelectionService _heroSelectionService;
        private readonly IViewFactory _viewFactory;

        private readonly IHeroListPanelView _view;

        public HeroListPanelPresenter(
            GetSelectedHeroIdUseCase getSelectedHeroIdIdUseCase,
            SetSelectedHeroIdUseCase setSelectedHeroIdUseCase,
            SaveProgressToLocalUseCase saveProgressToLocalUseCase,
            IConfigurationProvider configurationProvider,
            IHeroSelectionService heroSelectionService,
            IViewFactory viewFactory,
            IHeroListPanelView view,
            IWindowFsm<PanelType> windowFsm)
            : base(windowFsm, PanelType.HeroListPanel, view.Show, view.Hide)
        {
            _getSelectedHeroIdUseCase = getSelectedHeroIdIdUseCase;
            _setSelectedHeroIdUseCase = setSelectedHeroIdUseCase;
            _saveProgressToLocalUseCase = saveProgressToLocalUseCase;
            _configurationProvider = configurationProvider;
            _heroSelectionService = heroSelectionService;
            _viewFactory = viewFactory;
            _view = view;
        }

        protected override void OnAfterEnable()
        {
            _heroSelectionService.Focused += OnHeroFocused;

            int selectedHeroId = _getSelectedHeroIdUseCase.Execute();
            _heroSelectionService.FocusOn(_configurationProvider.HeroData.First(x => x.Id == selectedHeroId));

            _viewFactory.CreateHeroButtons(_view.HeroSelectorContainer);
            _view.CloseButton.onClick.AddListener(WindowFsm.CloseCurrentWindow);
        }

        protected override void OnAfterDisable()
        {
            _view.CloseButton.onClick.RemoveListener(WindowFsm.CloseCurrentWindow);
        }

        private void OnHeroFocused(HeroDto heroDto)
        {
            _viewFactory.CreateHeroModelView(heroDto, _view.HeroModelContainer);
            _setSelectedHeroIdUseCase.Execute(heroDto.Id);
            _saveProgressToLocalUseCase.Execute();
        }
    }
}