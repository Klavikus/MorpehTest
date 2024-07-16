using System;
using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace GameCore.Controllers.Presenters.Panels
{
    public abstract class PanelPresenterBase : IPresenter
    {
        private readonly Action _onOpenedBaseAction;
        private readonly Action _onClosedBaseAction;

        protected PanelPresenterBase(
            IWindowFsm<WindowType> windowFsm,
            WindowType windowType,
            Action onOpenedBaseAction = null,
            Action onClosedBaseAction = null)
        {
            WindowFsm = windowFsm ?? throw new ArgumentNullException(nameof(windowFsm));
            WindowType = windowType;
            _onOpenedBaseAction = onOpenedBaseAction;
            _onClosedBaseAction = onClosedBaseAction;
        }

        protected IWindowFsm<WindowType> WindowFsm { get; }
        protected WindowType WindowType { get; }

        public void Enable()
        {
            WindowFsm.Opened += OnOpened;
            WindowFsm.Closed += OnClosed;

            InitialCheck();

            OnAfterEnable();
        }

        public void Disable()
        {
            WindowFsm.Opened -= OnOpened;
            WindowFsm.Opened -= OnClosed;

            OnAfterDisable();
        }

        protected virtual void OnAfterEnable()
        {
        }

        protected virtual void OnAfterDisable()
        {
        }

        protected virtual void OnAfterOpened()
        {
        }

        protected virtual void OnAfterClosed()
        {
        }

        private void OnOpened(WindowType window)
        {
            if (window != WindowType)
                return;

            _onOpenedBaseAction?.Invoke();

            OnAfterOpened();
        }

        private void OnClosed(WindowType window)
        {
            if (window != WindowType)
                return;

            _onClosedBaseAction?.Invoke();

            OnAfterClosed();
        }

        private void InitialCheck()
        {
            if (WindowFsm.CurrentWindow == WindowType)
                _onOpenedBaseAction?.Invoke();
            else
                _onClosedBaseAction?.Invoke();
        }
    }
}