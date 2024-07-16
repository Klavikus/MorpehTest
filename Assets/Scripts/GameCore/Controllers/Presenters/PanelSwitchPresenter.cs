using System;
using System.Collections.Generic;
using GameCore.Domain.Windows.Panels;
using GameCore.Presentation.Abstract;
using GameCore.Presentation.Implementation.MainMenu;
using Modules.UI.MVPPassiveView.Runtime.Presenters;
using Modules.UI.WindowFsm.Runtime.Abstract;

namespace GameCore.Presentation.Implementation
{
    public class PanelSwitchPresenter : IPresenter
    {
        private readonly IPanelSwitchView _view;
        private readonly IWindowFsm _windowFsm;

        private readonly Dictionary<Type, IPanelSwitchButton> _buttonByWindow;
        private readonly Dictionary<IPanelSwitchButton, Action> _actionByButton;

        public PanelSwitchPresenter(IPanelSwitchView view, IWindowFsm windowFsm)
        {
            _view = view;
            _windowFsm = windowFsm;

            _buttonByWindow = new Dictionary<Type, IPanelSwitchButton>()
            {
                [typeof(ShopPanel)] = _view.ShopButton,
                [typeof(InventoryPanel)] = _view.InventoryButton,
                [typeof(FightPanel)] = _view.FightButton,
                [typeof(TalentsPanel)] = _view.TalentButton,
                [typeof(TowerPanel)] = _view.TowerButton,
            };

            _actionByButton = new Dictionary<IPanelSwitchButton, Action>()
            {
                [_view.ShopButton] = _windowFsm.OpenWindow<ShopPanel>,
                [_view.InventoryButton] = _windowFsm.OpenWindow<InventoryPanel>,
                [_view.FightButton] = _windowFsm.OpenWindow<FightPanel>,
                [_view.TalentButton] = _windowFsm.OpenWindow<TalentsPanel>,
                [_view.TowerButton] = _windowFsm.OpenWindow<TowerPanel>,
            };
        }

        public void Enable()
        {
            _view.Initialize();
            
            foreach (IPanelSwitchButton button in _buttonByWindow.Values)
                button.Clicked += OnClicked;
        }

        public void Disable()
        {
            foreach (IPanelSwitchButton button in _buttonByWindow.Values)
                button.Clicked -= OnClicked;

            _windowFsm.ClearHistory();
        }

        private void OnClicked(IPanelSwitchButton button)
        {
            _actionByButton[button].Invoke();

            foreach (var switchButton in _buttonByWindow.Values)
            {
                if (switchButton == button)
                    switchButton.Focus();
                else
                    switchButton.Unfocus();
            }
        }
    }
}