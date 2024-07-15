using System;
using Cysharp.Threading.Tasks;
using GameCore.Infrastructure;
using Modules.Infrastructure.Implementation.DI;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using VContainer;

namespace GameCore.Controllers.GameFSM.States
{
    public class MainMenuState : IState
    {

        private readonly SceneInitializer _sceneInitializer;
        private readonly SceneManipulator _sceneLoader;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IObjectResolver _objectResolver;

        public MainMenuState(
            SceneInitializer sceneInitializer,
            SceneManipulator sceneLoader,
            IConfigurationProvider configurationProvider,
            IObjectResolver objectResolver)
        {
            _sceneInitializer = sceneInitializer;
            _sceneLoader = sceneLoader;
            _configurationProvider = configurationProvider;
            _objectResolver = objectResolver;
        }

        public async void Enter()
        {
            // await _curtainService.Show();
            await _sceneLoader.Load(_configurationProvider.MainMenuSceneData);

            _sceneInitializer.Initialize(_objectResolver);
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            // await _curtainService.Hide();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}