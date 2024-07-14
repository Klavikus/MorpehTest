using System;
using Cysharp.Threading.Tasks;
using GameCore.Controllers.Services;
using Modules.Infrastructure.Implementation;
using Modules.Infrastructure.Implementation.DI;
using Modules.Infrastructure.Interfaces.GameFsm;
using VContainer;

namespace GameCore.Controllers.GameFSM.States
{
    public class GameLoopState : IState
    {
        private const string s_gameLoopScene = "GameLoop";

        private readonly SceneInitializer _sceneInitializer;
        private readonly IObjectResolver _objectResolver;
        private readonly ICurtainService _curtainService;
        private readonly SceneLoader _sceneLoader;

        public GameLoopState(
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
            await _sceneLoader.LoadAsync(s_gameLoopScene);
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