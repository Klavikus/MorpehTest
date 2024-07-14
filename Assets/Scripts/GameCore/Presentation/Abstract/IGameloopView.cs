using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine.UI;

namespace GameCore.Presentation.Abstract
{
    public interface IGameloopView : IView, IShowHide
    {
        Button ToMainMenu { get; }
    }
}