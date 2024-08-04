using System;
using Modules.DAL.Runtime.Abstract.Repositories;

namespace GameCore.Controllers.Implementation.UseCases.HeroSelection
{
    public class SetSelectedHeroIdUseCase
    {
        private readonly ICompositeRepository _compositeRepository;

        public SetSelectedHeroIdUseCase(ICompositeRepository compositeRepository)
        {
            _compositeRepository = compositeRepository ?? throw new ArgumentNullException(nameof(compositeRepository));
        }

        public void Execute(int heroId)
        {
            Domain.Models.HeroSelection heroSelection = _compositeRepository.GetById<Domain.Models.HeroSelection>(Domain.Models.HeroSelection.DefaultId) ??
                                                        _compositeRepository.Add<Domain.Models.HeroSelection>(new Domain.Models.HeroSelection()) as Domain.Models.HeroSelection;
            if (heroSelection != null)
                heroSelection.SelectedId.Value = heroId;
        }
    }
}