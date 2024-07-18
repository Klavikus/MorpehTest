using System;
using GameCore.Domain.Models;
using GameCore.Infrastructure.Factories;
using GameCore.Presentation.Implementation;
using GameCore.UseCases;
using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace GameCore.Controllers.Presenters
{
    public class MetaMainHeaderPresenter : IPresenter
    {
        private readonly ViewBuilder _viewBuilder;
        private readonly GetPlayerLevelUseCase _getPlayerLevelUseCase;
        private readonly GetPlayerCurrencyUseCase _getPlayerCurrencyUseCase;
        private readonly MetaMainHeaderView _view;

        public MetaMainHeaderPresenter(
            ViewBuilder viewBuilder,
            GetPlayerLevelUseCase getPlayerLevelUseCase,
            GetPlayerCurrencyUseCase getPlayerCurrencyUseCase,
            MetaMainHeaderView view)
        {
            _viewBuilder = viewBuilder ?? throw new ArgumentNullException(nameof(viewBuilder));
            _getPlayerLevelUseCase =
                getPlayerLevelUseCase ?? throw new ArgumentNullException(nameof(getPlayerLevelUseCase));
            _getPlayerCurrencyUseCase = getPlayerCurrencyUseCase;
            _view = view ? view : throw new ArgumentNullException(nameof(view));
        }

        public void Enable()
        {
            PlayerLevel playerLevel = _getPlayerLevelUseCase.Execute();
            PlayerCurrency playerCurrency = _getPlayerCurrencyUseCase.Execute();

            _viewBuilder.BuildBar(_view.LevelBar, playerLevel.CurrentExp, playerLevel.ExpToLevelup);
            _viewBuilder.BuildCounter(_view.LevelCounter, playerLevel.CurrentLevel);
            _viewBuilder.BuildCounter(_view.SoftCurrency, playerCurrency.Soft);
            _viewBuilder.BuildCounter(_view.HardCurrency, playerCurrency.Hard);
        }

        public void Disable()
        {
        }
    }
}