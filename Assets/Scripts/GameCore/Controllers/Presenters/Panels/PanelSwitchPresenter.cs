using GameCore.Controllers.Services;
using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Presenters;

namespace GameCore.Controllers.Presenters.Panels
{
    public class EnumPanelSwitchPresenter : IPresenter
    {
        private readonly IPanelSwitchView _view;
        private readonly IWindowFsm<WindowType> _windowFsm;
        private readonly IPanelAccessService _panelAccessService;

        public EnumPanelSwitchPresenter(
            IPanelSwitchView view,
            IWindowFsm<WindowType> windowFsm,
            IPanelAccessService panelAccessService)
        {
            _view = view;
            _windowFsm = windowFsm;
            _panelAccessService = panelAccessService;
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
            if (_panelAccessService.CheckAllowStatus(button.WindowType) == false)
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