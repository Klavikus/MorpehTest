using GameCore.Presentation.Abstract;
using R3;

namespace GameCore.Infrastructure.Abstraction.Factories
{
    public interface IViewBuilder
    {
        IBarView BuildBar(IBarView view, ReactiveProperty<int> currentValue, ReactiveProperty<int> maxValue);

        ICountView<T> BuildCounter<T>(ICountView<T> view, ReactiveProperty<T> property)
            where T : struct;
    }
}