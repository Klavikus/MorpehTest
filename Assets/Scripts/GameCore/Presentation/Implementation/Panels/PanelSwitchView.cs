using System;
using System.Linq;
using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;

namespace GameCore.Presentation.Implementation.MainMenu
{
    class PanelSwitchView : ViewBase, IPanelSwitchView
    {
        [SerializeField] private PanelSwitchButton[] _switchButtons;
        public IPanelSwitchButton[] SwitchButtons { get; private set; }

        public void Initialize()
        {
            // TODO: Добавить описание ошибки
            if (_switchButtons == null)
                throw new Exception();

            foreach (IPanelSwitchButton switchButton in _switchButtons) 
                switchButton.Initialize();

            SwitchButtons = _switchButtons.Cast<IPanelSwitchButton>().ToArray();
        }
    }
}