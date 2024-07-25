using GameCore.Controllers.Implementation.GameFSM.States;
using GameCore.Controllers.Implementation.UseCases;
using GameCore.Domain.Models;
using GameCore.Infrastructure.Abstraction;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;

namespace GameCore.Controllers.Implementation.Services
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