using System;
using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Presenters;
using R3;

namespace GameCore.Controllers.Implementation.Presenters
{
    public class CountPresenter<T> : IPresenter
        where T : struct
    {
        private readonly ICountView<T> _view;
        private readonly ReactiveProperty<T> _countValue;

        private IDisposable _disposable;

        public CountPresenter(ICountView<T> view, ReactiveProperty<T> countValue)
        {
            _view = view;
            _countValue = countValue;
        }

        public void Enable()
        {
            _disposable = _countValue.Subscribe(_view.Fill);
        }

        public void Disable()
        {
            _disposable.Dispose();
        }
    }
}