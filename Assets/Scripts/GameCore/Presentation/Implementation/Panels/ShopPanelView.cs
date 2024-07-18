using GameCore.Presentation.Abstract.Panels;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation.Panels
{
    public class ShopPanelView : ViewBase, IShopPanelView
    {
        [SerializeField] private Canvas _canvas;
        [field: SerializeField] public Button AddExpButton { get; private set; }

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