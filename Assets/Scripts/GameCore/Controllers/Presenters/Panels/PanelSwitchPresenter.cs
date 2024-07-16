using System.Collections.Generic;
using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace GameCore.Controllers.Presenters.Panels
{
    public class EnumPanelSwitchPresenter : IPresenter
    {
        private readonly IPanelSwitchView _view;
        private readonly IWindowFsm<WindowType> _windowFsm;

        private readonly Stack<WindowType> _allowedWindows;

        public EnumPanelSwitchPresenter(IPanelSwitchView view, IWindowFsm<WindowType> windowFsm)
        {
            _view = view;
            _windowFsm = windowFsm;

            _allowedWindows = new Stack<WindowType>();
            _allowedWindows.Push(WindowType.FightPanel);
            _allowedWindows.Push(WindowType.ShopPanel);
        }

        public void Enable()
        {
            _view.Initialize();

            foreach (IPanelSwitchButton button in _view.SwitchButtons)
            {
                button.Clicked += OnClicked;

                if (button.WindowType == _windowFsm.CurrentWindow)
                    button.Focus();
            }
        }

        public void Disable()
        {
            foreach (IPanelSwitchButton button in _view.SwitchButtons)
                button.Clicked -= OnClicked;

            _windowFsm.ClearHistory();
        }

        private void OnClicked(IPanelSwitchButton button)
        {
            if (_allowedWindows.Contains(button.WindowType) == false)
                return;

            _windowFsm.OpenWindow(button.WindowType);

            foreach (IPanelSwitchButton switchButton in _view.SwitchButtons)
            {
                if (switchButton == button)
                    switchButton.Focus();
                else
                    switchButton.Unfocus();
            }
        }
    }
}