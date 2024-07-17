using GameCore.Domain.Models;

namespace GameCore.UseCases
{
    public class AddPlayerExpUseCase
    {
        private readonly GetPlayerLevelUseCase _getPlayerLevelUseCase;

        public AddPlayerExpUseCase(GetPlayerLevelUseCase getPlayerLevelUseCase)
        {
            _getPlayerLevelUseCase = getPlayerLevelUseCase;
        }

        public void Execute()
        {
            PlayerLevel playerLevel = _getPlayerLevelUseCase.Execute();

            playerLevel.AddExp(30);
        }
    }
}