using GameCore.Presentation.Implementation.MainMenu;
using Modules.UI.MVPPassiveView.Runtime.Views;

namespace GameCore.Presentation.Abstract
{
    public interface IPanelSwitchView : IView
    {
        PanelSwitchButton ShopButton { get; }
        PanelSwitchButton InventoryButton { get; }
        PanelSwitchButton FightButton { get; }
        PanelSwitchButton TalentButton { get; }
        PanelSwitchButton TowerButton { get; }
        void Initialize();
    }
}