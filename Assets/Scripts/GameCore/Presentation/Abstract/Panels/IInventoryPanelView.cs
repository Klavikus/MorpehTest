using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine.UI;

namespace GameCore.Presentation.Abstract.Panels
{
    public interface IInventoryPanelView : IView, IShowHide
    {
        Button HeroListButton { get; }
    }
}