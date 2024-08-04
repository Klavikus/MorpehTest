using Modules.DAL.Runtime.Abstract.Repositories;

namespace GameCore.Controllers.Implementation.UseCases
{
    public class GetSelectedLevelIdUseCase
    {
        private readonly GetLevelSelectionUseCase _getLevelSelectionUseCase;
        private readonly ICompositeRepository _compositeRepository;

        public GetSelectedLevelIdUseCase(GetLevelSelectionUseCase getLevelSelectionUseCase)
        {
            _getLevelSelectionUseCase = getLevelSelectionUseCase;
        }

        public int Execute() =>
            _getLevelSelectionUseCase.Execute().SelectedId.CurrentValue;
    }
}