using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Abstract.Panels
{
    public interface IHeroListPanelView : IView, IShowHide
    {
        Button CloseButton { get; }
        Button SelectButton { get; }
        Transform HeroSelectorContainer { get; }
        Transform HeroModelContainer { get; }
    }
}