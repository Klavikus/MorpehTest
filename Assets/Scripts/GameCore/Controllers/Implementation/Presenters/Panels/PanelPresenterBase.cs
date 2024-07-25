using System;
using GameCore.Domain.Enums;
using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace GameCore.Controllers.Implementation.Presenters.Panels
{
    public abstract class PanelPresenterBase : IPresenter
    {
        private readonly Action _onOpenedBaseAction;
        private readonly Action _onClosedBaseAction;

        protected PanelPresenterBase(
            IWindowFsm<PanelType> windowFsm,
            PanelType panelType,
            Action onOpenedBaseAction = null,
            Action onClosedBaseAction = null)
        {
            WindowFsm = windowFsm ?? throw new ArgumentNullException(nameof(windowFsm));
            PanelType = panelType;
            _onOpenedBaseAction = onOpenedBaseAction;
            _onClosedBaseAction = onClosedBaseAction;
        }

        protected IWindowFsm<PanelType> WindowFsm { get; }
        protected PanelType PanelType { get; }

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

        private void OnOpened(PanelType panel)
        {
            if (panel != PanelType)
                return;

            _onOpenedBaseAction?.Invoke();

            OnAfterOpened();
        }

        private void OnClosed(PanelType panel)
        {
            if (panel != PanelType)
                return;

            _onClosedBaseAction?.Invoke();

            OnAfterClosed();
        }

        private void InitialCheck()
        {
            if (WindowFsm.CurrentWindow == PanelType)
                _onOpenedBaseAction?.Invoke();
            else
                _onClosedBaseAction?.Invoke();
        }
    }
}