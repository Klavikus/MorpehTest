using System;
using GameCore.Domain.Models;
using Modules.DAL.Runtime.Abstract.Repositories;

namespace GameCore.Controllers.Implementation.UseCases
{
    public class GetPlayerLevelUseCase
    {
        private readonly ICompositeRepository _compositeRepository;

        public GetPlayerLevelUseCase(ICompositeRepository compositeRepository)
        {
            _compositeRepository = compositeRepository ?? throw new ArgumentNullException(nameof(compositeRepository));
        }

        public PlayerLevel Execute() =>
            _compositeRepository.GetById<PlayerLevel>(PlayerLevel.DefaultId) ??
            _compositeRepository.Add<PlayerLevel>(new PlayerLevel()) as PlayerLevel;
    }
}