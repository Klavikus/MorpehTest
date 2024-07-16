﻿using Cysharp.Threading.Tasks;
using GameCore.Controllers.Presenters;
using GameCore.Controllers.Services.Loading;
using GameCore.Presentation.Abstract;
using GameCore.Presentation.Implementation;
using Qw1nt.Runtime.AddressablesContentController.Core;
using UnityEngine;

namespace GameCore.Infrastructure.Factories
{
    public class LoadingScreenFactory : ILoadingScreenFactory
    {
        private readonly ContentController _contentController;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly ILoadingService _loadingService;

        public LoadingScreenFactory(
            ContentController contentController,
            IConfigurationProvider configurationProvider,
            ILoadingService loadingService)
        {
            _contentController = contentController;
            _configurationProvider = configurationProvider;
            _loadingService = loadingService;
        }

        public async UniTask<ILoadingScreenView> Create()
        {
            LoadingScreenView view = await _contentController.InstantiateAsync<LoadingScreenView>(
                _configurationProvider.LoadingScreenViewReference);
            LoadingPresenter presenter = new(view, _loadingService);
            view.Construct(presenter);
            Object.DontDestroyOnLoad(view.gameObject);

            return view;
        }
    }
}