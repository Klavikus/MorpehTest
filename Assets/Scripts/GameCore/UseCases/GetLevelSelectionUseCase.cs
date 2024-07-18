using System;
using GameCore.Domain.Models;
using Modules.DAL.Runtime.Abstract.Repositories;

namespace GameCore.UseCases
{
    public class GetLevelSelectionUseCase
    {
        private readonly ICompositeRepository _compositeRepository;

        public GetLevelSelectionUseCase(ICompositeRepository compositeRepository)
        {
            _compositeRepository = compositeRepository ?? throw new ArgumentNullException(nameof(compositeRepository));
        }

        public LevelSelection Execute() =>
            _compositeRepository.GetById<LevelSelection>(LevelSelection.DefaultId) ??
            _compositeRepository.Add<LevelSelection>(new LevelSelection()) as LevelSelection;
    }
}