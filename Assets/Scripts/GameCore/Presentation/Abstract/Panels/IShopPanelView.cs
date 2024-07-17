using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine.UI;

namespace GameCore.Presentation.Abstract
{
    public interface IShopPanelView : IView, IShowHide
    {
        Button AddExpButton { get; }
    }
}