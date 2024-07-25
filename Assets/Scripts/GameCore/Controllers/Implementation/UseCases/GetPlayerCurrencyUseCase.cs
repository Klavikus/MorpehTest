using System;
using GameCore.Domain.Models;
using Modules.DAL.Runtime.Abstract.Repositories;

namespace GameCore.Controllers.Implementation.UseCases
{
    public class GetPlayerCurrencyUseCase
    {
        private readonly ICompositeRepository _compositeRepository;

        public GetPlayerCurrencyUseCase(ICompositeRepository compositeRepository)
        {
            _compositeRepository = compositeRepository ?? throw new ArgumentNullException(nameof(compositeRepository));
        }

        public PlayerCurrency Execute() =>
            _compositeRepository.GetById<PlayerCurrency>(PlayerCurrency.DefaultId) ??
            _compositeRepository.Add<PlayerCurrency>(new PlayerCurrency()) as PlayerCurrency;
    }
}