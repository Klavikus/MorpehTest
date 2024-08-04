using GameCore.Controllers.Abstracion.Services;
using GameCore.Controllers.Implementation.Services;
using GameCore.Domain.Dto;
using GameCore.Presentation.Implementation;
using GameCore.Presentation.Implementation.HeroSelection;
using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace GameCore.Controllers.Implementation.Presenters.HeroSelections
{
    public class HeroSelectorPresenter : IPresenter
    {
        private readonly IHeroSelectionService _heroSelectionService;
        private readonly HeroSelector _view;
        private readonly HeroDto _heroDto;

        public HeroSelectorPresenter(
            IHeroSelectionService heroSelectionService,
            HeroSelector view,
            HeroDto heroDto)
        {
            _heroSelectionService = heroSelectionService;
            _view = view;
            _heroDto = heroDto;
        }

        public void Enable()
        {
            _view.SelectButton.onClick.AddListener(OnSelectButtonClicked);
            _view.Avatar.sprite = _heroDto.Avatar;
        }

        public void Disable()
        {
            _view.SelectButton.onClick.RemoveListener(OnSelectButtonClicked);
        }

        private void OnSelectButtonClicked()
        {
            _heroSelectionService.FocusOn(_heroDto);

            // HeroView[] heroViews = _heroButton.PrefabContainer.GetComponentsInChildren<HeroView>();
            //
            // for (var i = 0; i < heroViews.Length; i++)
            // {
            //     HeroView heroView = heroViews[i];
            //     Object.Destroy(heroView.gameObject);
            // }
            //
            // var contentOperation = await _contentController.LoadAsync<GameObject>(_heroDto.Reference);
            //
            // Object.Instantiate(contentOperation.GetResult(), _heroButton.PrefabContainer);
        }
    }
}