using System;
using Modules.DAL.Runtime.Abstract.Repositories;

namespace GameCore.Controllers.Implementation.UseCases.HeroSelection
{
    public class GetSelectedHeroUseCase
    {
        private readonly ICompositeRepository _compositeRepository;

        public GetSelectedHeroUseCase(ICompositeRepository compositeRepository)
        {
            _compositeRepository = compositeRepository ?? throw new ArgumentNullException(nameof(compositeRepository));
        }

        public Domain.Models.HeroSelection Execute()
        {
            return _compositeRepository.GetById<Domain.Models.HeroSelection>(Domain.Models.HeroSelection.DefaultId) ??
                   _compositeRepository.Add<Domain.Models.HeroSelection>(new Domain.Models.HeroSelection()) as Domain.Models.HeroSelection;
        }
    }
}