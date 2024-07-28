using System;
using System.Collections.Generic;
using GameCore.Controllers.Implementation.Presenters.HeroSelections;
using GameCore.Controllers.Implementation.Services;
using GameCore.Domain.Dto;
using GameCore.Infrastructure.Abstraction;
using GameCore.Presentation.Implementation;
using Qw1nt.Runtime.AddressablesContentController.Common;
using Qw1nt.Runtime.AddressablesContentController.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using VContainer;
using Object = UnityEngine.Object;

namespace GameCore.Infrastructure.Implementation.Factories
{
    public class ViewFactory : IViewFactory, IDisposable
    {
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IObjectResolver _objectResolver;

        private readonly Dictionary<AssetReference, ContentOperation<GameObject>> _contentOperations = new();
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

            for (int i = 0; i < views.Length; i++)
                Object.Destroy(views[i].gameObject);

            GameObject heroView;

            if (_contentOperations.ContainsKey(heroDto.Reference))
            {
                heroView = Object.Instantiate(_contentOperations[heroDto.Reference].GetResult(), parent);
                heroView.AddComponent<HeroView>();
            }
            else
            {
                ContentOperation<GameObject> contentOperation =
                    await _contentController.LoadAsync<GameObject>(heroDto.Reference);
                _contentOperations.Add(heroDto.Reference, contentOperation);
                heroView = Object.Instantiate(contentOperation.GetResult(), parent);
                heroView.AddComponent<HeroView>();
            }
        }

        public void Dispose()
        {
            Debug.Log($"ViewFactory disposed");

            foreach (AssetReference contentOperation in _contentOperations.Keys)
            {
                contentOperation.ReleaseAsset();
                _contentController.Release(contentOperation);
            }

            _contentOperations.Clear();
        }
    }
}