using GameCore.Presentation.Abstract.Panels;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation.Panels
{
    public class HeroListPanelView : ViewBase, IHeroListPanelView
    {
        [SerializeField] private Canvas _canvas;

        [field: SerializeField] public Transform HeroSelectorContainer { get; private set; }
        [field: SerializeField] public Transform HeroModelContainer { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }
        [field: SerializeField] public Button SelectButton { get; private set; }

        public void Show()
        {
            _canvas.enabled = true;
        }

        public void Hide()
        {
            _canvas.enabled = false;
        }
    }
}