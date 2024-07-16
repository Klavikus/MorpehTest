using System;
using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;

namespace GameCore.Presentation.Implementation.MainMenu
{
    class PanelSwitchView : ViewBase, IPanelSwitchView
    {
        [field: SerializeField] public PanelSwitchButton ShopButton { get; private set; }
        [field: SerializeField] public PanelSwitchButton InventoryButton { get; private set; }
        [field: SerializeField] public PanelSwitchButton FightButton { get; private set; }
        [field: SerializeField] public PanelSwitchButton TalentButton { get; private set; }
        [field: SerializeField] public PanelSwitchButton TowerButton { get; private set; }

        public void Initialize()
        {
            ShopButton.Initialize();
            InventoryButton.Initialize();
            FightButton.Initialize();
            TalentButton.Initialize();
            TowerButton.Initialize();
        }
    }
}