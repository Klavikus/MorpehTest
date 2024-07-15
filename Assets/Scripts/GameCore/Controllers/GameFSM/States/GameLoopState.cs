using System;
using Cysharp.Threading.Tasks;
using GameCore.Infrastructure;
using Modules.Infrastructure.Implementation.DI;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;
using VContainer;

namespace GameCore.Controllers.GameFSM.States
{
    public class GameLoopState : IState
    {
        private readonly SceneInitializer _sceneInitializer;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IObjectResolver _objectResolver;
        private readonly SceneManipulator _sceneLoader;

        public GameLoopState(
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
            await _sceneLoader.Load(_configurationProvider.GameloopSceneData);
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