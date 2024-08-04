namespace GameCore.Controllers.Implementation.UseCases.HeroSelection
{
    public class GetSelectedHeroIdUseCase
    {
        private readonly GetSelectedHeroUseCase _getSelectedHeroUseCase;

        public GetSelectedHeroIdUseCase(GetSelectedHeroUseCase getSelectedHeroUseCase)
        {
            _getSelectedHeroUseCase = getSelectedHeroUseCase;
        }

        public int Execute() =>
            _getSelectedHeroUseCase.Execute().SelectedId.CurrentValue;
    }
}