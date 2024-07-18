using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine.UI;

namespace GameCore.Presentation.Abstract.Panels
{
    public interface IFightPanelView : IView, IShowHide
    {
        Button StartButton { get; }
    }
}