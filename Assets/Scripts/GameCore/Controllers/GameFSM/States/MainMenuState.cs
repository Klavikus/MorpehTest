using System;
using Cysharp.Threading.Tasks;
using GameCore.Controllers.Services.Loading;
using GameCore.Infrastructure;
using Modules.Infrastructure.Implementation.DI;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.AddressablesContentController.Common;
using Qw1nt.Runtime.AddressablesContentController.Extensions;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using VContainer;

namespace GameCore.Controllers.GameFSM.States
{
    public class MainMenuState : IState
    {
        private readonly ILoadingService _loadingService;
        private readonly SceneInitializer _sceneInitializer;
        private readonly SceneManipulator _sceneLoader;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IObjectResolver _objectResolver;

        public MainMenuState(
            ILoadingService loadingService,
            SceneInitializer sceneInitializer,
            SceneManipulator sceneLoader,
            IConfigurationProvider configurationProvider,
            IObjectResolver objectResolver)
        {
            _loadingService = loadingService;
            _sceneInitializer = sceneInitializer;
            _sceneLoader = sceneLoader;
            _configurationProvider = configurationProvider;
            _objectResolver = objectResolver;
        }

        public void Enter()
        {
            // await _sceneLoader.Load(_configurationProvider.MainMenuSceneData);
            // _sceneInitializer.Initialize(_objectResolver);

            _loadingService.Purge();

            _loadingService.AddToQueue(async progress =>
            {
                _sceneLoader.Preloader.Schedule(_configurationProvider.MainMenuSceneData, new OperationObserver().OnUpdate(progress.Report));
                await _sceneLoader.Load(_configurationProvider.MainMenuSceneData);
            }, "Scene loading");

            _loadingService.AddToQueue(async progress =>
            {
                progress.Report(0);
                // await UniTask.Delay(TimeSpan.FromSeconds(2));
                await _sceneInitializer.Initialize(_objectResolver);
                progress.Report(1);
            }, "Scene Initializing");

            _loadingService.Load().Forget();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}