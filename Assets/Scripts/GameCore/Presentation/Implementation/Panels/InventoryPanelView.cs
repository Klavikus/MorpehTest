using GameCore.Presentation.Abstract.Panels;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation.Panels
{
    public class InventoryPanelView : ViewBase, IInventoryPanelView
    {
        [SerializeField] private Canvas _canvas;

        [field: SerializeField] public Button HeroListButton { get; private set; }

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