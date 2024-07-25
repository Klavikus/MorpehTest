using System;
using GameCore.Controllers.Implementation.Presenters;
using GameCore.Controllers.Implementation.UseCases;
using GameCore.Presentation.Implementation;
using R3;
using VContainer;

namespace GameCore.Infrastructure.Implementation.Factories
{
    public class ViewBuilder : IViewBuilder
    {
        private readonly IObjectResolver _objectResolver;
        private readonly GetPlayerLevelUseCase _getPlayerLevelUseCase;

        public ViewBuilder(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver ?? throw new ArgumentNullException(nameof(objectResolver));
        }

        public IBarView BuildBar(IBarView view, ReactiveProperty<int> currentValue, ReactiveProperty<int> maxValue)
        {
            view.Construct(new BarPresenter(view, currentValue, maxValue));

            return view;
        }

        public ICountView<T> BuildCounter<T>(ICountView<T> view, ReactiveProperty<T> property)
            where T : struct
        {
            view.Construct(new CountPresenter<T>(view, property));

            return view;
        }
    }
}