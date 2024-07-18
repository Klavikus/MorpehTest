using GameCore.Controllers.GameFSM.States;
using GameCore.Domain.Models;
using GameCore.Infrastructure;
using GameCore.UseCases;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;

namespace GameCore.Controllers.Services
{
    public class LevelLoadingService
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly GetLevelSelectionUseCase _getLevelSelectionUseCase;

        public LevelLoadingService(
            IGameStateMachine gameStateMachine,
            IConfigurationProvider configurationProvider,
            GetLevelSelectionUseCase getLevelSelectionUseCase)
        {
            _gameStateMachine = gameStateMachine;
            _configurationProvider = configurationProvider;
            _getLevelSelectionUseCase = getLevelSelectionUseCase;
        }

        public void StartSelected()
        {
            LevelSelection levelSelection = _getLevelSelectionUseCase.Execute();

            int selectedLevelId = levelSelection.SelectedId.CurrentValue;
            SceneData sceneData = _configurationProvider.GetLevelConfig(selectedLevelId);

            _gameStateMachine.Enter<GameLoopState, SceneData>(sceneData);
        }
    }
}