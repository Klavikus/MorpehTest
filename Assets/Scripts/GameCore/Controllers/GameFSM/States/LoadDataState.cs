using System;
using Cysharp.Threading.Tasks;
using GameCore.Controllers.Services.Loading;
using GameCore.Infrastructure;
using Modules.Infrastructure.Interfaces.GameFsm;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace GameCore.Controllers.GameFSM.States
{
    public class LoadDataState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ILoadingService _loadingService;
        private readonly IConfigurationProvider _configurationProvider;

        public LoadDataState(
            IGameStateMachine gameStateMachine,
            ILoadingService loadingService,
            IConfigurationProvider configurationProvider)
        {
            _gameStateMachine = gameStateMachine;
            _loadingService = loadingService;
            _configurationProvider = configurationProvider;
        }

        public async void Enter()
        {
            _loadingService.Purge();
            _loadingService.AddToQueue(async (progress) =>
                {
                    progress.Report(0);
                    await new TestLoading().Load(1);
                    progress.Report(1);
                },
                "Load configs 1");
            _loadingService.AddToQueue(async (progress) =>
                {
                    progress.Report(0);
                    await new TestLoading().Load(1);
                    progress.Report(1);
                },
                "Load configs 2");
            _loadingService.AddToQueue(async (progress) =>
                {
                    progress.Report(0);
                    await new TestLoading().Load(1);
                    progress.Report(1);
                },
                "Load configs 3");

            await _loadingService.Load();

            _gameStateMachine.Enter<MainMenuState>();
        }

        public void Exit()
        {
        }

        public void Update()
        {
        }
    }

    public class TestLoading
    {
        public UniTask Load(float seconds) =>
            UniTask.Delay(TimeSpan.FromSeconds(seconds));
    }
}