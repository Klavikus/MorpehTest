using GameCore.Presentation.Implementation;
using R3;

namespace GameCore.Infrastructure.Implementation.Factories
{
    public interface IViewBuilder
    {
        IBarView BuildBar(IBarView view, ReactiveProperty<int> currentValue, ReactiveProperty<int> maxValue);

        ICountView<T> BuildCounter<T>(ICountView<T> view, ReactiveProperty<T> property)
            where T : struct;
    }
}