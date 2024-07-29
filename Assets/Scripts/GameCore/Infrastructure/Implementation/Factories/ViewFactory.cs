using GameCore.Controllers.Implementation.Presenters.HeroSelections;
using GameCore.Controllers.Implementation.Services;
using GameCore.Domain.Dto;
using GameCore.Infrastructure.Abstraction;
using GameCore.Presentation.Implementation;
using Qw1nt.Runtime.AddressablesContentController.Common;
using Qw1nt.Runtime.AddressablesContentController.Core;
using UnityEngine;
using VContainer;

namespace GameCore.Infrastructure.Implementation.Factories
{
    public class ViewFactory : IViewFactory
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IObjectResolver _objectResolver;

        private readonly ContentController _contentController;

        public ViewFactory(
            IConfigurationProvider configurationProvider,
            ContentController contentController,
            IObjectResolver objectResolver
        )
        {
            _configurationProvider = configurationProvider;
            _contentController = contentController;
            _objectResolver = objectResolver;
        }

        public void CreateHeroButtons(Transform parent)
        {
            foreach (HeroDto dto in _configurationProvider.HeroData)
                CreateHeroSelector(parent, dto);
        }

        private void CreateHeroSelector(Transform parent, HeroDto dto)
        {
            HeroSelector view = Object.Instantiate(_configurationProvider.HeroSelector, parent)
                .GetComponent<HeroSelector>();
            IHeroSelectionService heroSelectionService = _objectResolver.Resolve<IHeroSelectionService>();
            HeroSelectorPresenter presenter = new(heroSelectionService, view, dto);
            view.Construct(presenter);
        }

        public async void CreateHeroModelView(HeroDto heroDto, Transform parent)
        {
            HeroView[] views = parent.GetComponentsInChildren<HeroView>();

            foreach (HeroView view in views)
                Object.Destroy(view.gameObject);

            ContentOperation<GameObject> contentOperation =
                await _contentController.LoadAsync<GameObject>(heroDto.Reference);
            GameObject heroView = Object.Instantiate(contentOperation.GetResult(), parent);
            heroView.AddComponent<HeroView>();
        }
    }
}