using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine.UI;

namespace GameCore.Presentation.Abstract
{
    public interface IMainMenuView : IView, IShowHide
    {
        Button ToGameloop { get; }
    }
}