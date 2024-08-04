using Modules.DAL.Runtime.Abstract.Repositories;

namespace GameCore.Controllers.Implementation.UseCases
{
    public class SetSelectedLevelIdUseCase
    {
        private readonly GetLevelSelectionUseCase _getLevelSelectionUseCase;
        private readonly ICompositeRepository _compositeRepository;

        public SetSelectedLevelIdUseCase(GetLevelSelectionUseCase getLevelSelectionUseCase)
        {
            _getLevelSelectionUseCase = getLevelSelectionUseCase;
        }

        public void Execute(int id) =>
            _getLevelSelectionUseCase.Execute().Select(id);
    }
}