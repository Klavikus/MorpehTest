using System;
using Cysharp.Threading.Tasks;
using GameCore.Controllers.Abstracion.Services.Loading;
using GameCore.Controllers.Implementation.Services.Loading;
using GameCore.Controllers.Implementation.UseCases;
using GameCore.Controllers.Implementation.UseCases.Progress;
using GameCore.Infrastructure.Abstraction;
using Modules.Infrastructure.Interfaces.GameFsm;

namespace GameCore.Controllers.Implementation.GameFSM.States
{
    public class LoadDataState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ILoadingService _loadingService;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly LoadProgressUseCase _loadProgressUseCase;

        public LoadDataState(
            IGameStateMachine gameStateMachine,
            ILoadingService loadingService,
            IConfigurationProvider configurationProvider,
            LoadProgressUseCase loadProgressUseCase)
        {
            _gameStateMachine = gameStateMachine;
            _loadingService = loadingService;
            _configurationProvider = configurationProvider;
            _loadProgressUseCase = loadProgressUseCase;
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
                    await _loadProgressUseCase.Execute();
                    progress.Report(1);
                },
                "Load progress");

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