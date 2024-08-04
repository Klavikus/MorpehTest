using System;
using GameCore.Controllers.Abstracion.Services;
using GameCore.Domain.Dto;
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
            _heroSelectionService.Focused += OnHeroFocused;
            OnHeroFocused(_heroSelectionService.FocusedOn);
        }

        public void Disable()
        {
            _view.SelectButton.onClick.RemoveListener(OnSelectButtonClicked);
            _heroSelectionService.Focused -= OnHeroFocused;
        }

        private void OnSelectButtonClicked()
        {
            _heroSelectionService.FocusOn(_heroDto);
        }

        private void OnHeroFocused(HeroDto heroDto)
        {
            if (heroDto == null)
                throw new ArgumentNullException(nameof(heroDto));

            _view.SelectionBorder.enabled = _heroDto.Id == heroDto.Id;
        }
    }
}