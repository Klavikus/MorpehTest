using Modules.UI.MVPPassiveView.Runtime.Views;

namespace GameCore.Presentation.Abstract.Panels
{
    public interface IPanelSwitchView : IView
    {
        IPanelSwitchButton[] SwitchButtons { get; }
        void Initialize();
    }
}