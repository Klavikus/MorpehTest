using System;
using System.Collections.Generic;
using GameCore.Presentation.Implementation;
using Modules.UI.MVPPassiveView.Runtime.Presenters;
using R3;

namespace GameCore.Controllers.Implementation.Presenters
{
    public class BarPresenter : IPresenter
    {
        private readonly IBarView _view;
        private readonly ReactiveProperty<int> _currentValue;
        private readonly ReactiveProperty<int> _maxValue;

        private readonly ICollection<IDisposable> _disposable = new List<IDisposable>();

        public BarPresenter(IBarView view, ReactiveProperty<int> currentValue, ReactiveProperty<int> maxValue)
        {
            _view = view;
            _currentValue = currentValue;
            _maxValue = maxValue;
        }

        public void Enable()
        {
            _currentValue.Subscribe(x => UpdateView(x, _maxValue.Value)).AddTo(_disposable);
        }

        public void Disable()
        {
            foreach (IDisposable disposable in _disposable)
                disposable.Dispose();

            _disposable.Clear();
        }

        private void UpdateView(int currentValue, int maxValue)
        {
            _view.Fill(currentValue, maxValue);
        }
    }
}