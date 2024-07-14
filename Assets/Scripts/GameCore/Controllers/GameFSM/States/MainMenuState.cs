using System;
using Cysharp.Threading.Tasks;
using GameCore.Controllers.Services;
using Modules.Infrastructure.Implementation;
using Modules.Infrastructure.Implementation.DI;
using Modules.Infrastructure.Interfaces.GameFsm;
using VContainer;

namespace GameCore.Controllers.GameFSM.States
{
    public class MainMenuState : IState
    {
        private const string s_mainMenuScene = "MainMenu";

        private readonly SceneInitializer _sceneInitializer;
        private readonly SceneLoader _sceneLoader;
        private readonly IObjectResolver _objectResolver;
        private readonly ICurtainService _curtainService;

        public MainMenuState(
            SceneInitializer sceneInitializer,
            SceneLoader sceneLoader,
            IObjectResolver objectResolver,
            ICurtainService curtainService)
        {
            _sceneInitializer = sceneInitializer;
            _sceneLoader = sceneLoader;
            _objectResolver = objectResolver;
            _curtainService = curtainService;
        }

        public async void Enter()
        {
            await _curtainService.Show();
            await _sceneLoader.LoadAsync(s_mainMenuScene);
            _sceneInitializer.Initialize(_objectResolver);
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            await _curtainService.Hide();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }
}