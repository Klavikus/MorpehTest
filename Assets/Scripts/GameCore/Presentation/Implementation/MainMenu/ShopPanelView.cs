using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;

namespace GameCore.Presentation.Implementation.MainMenu
{
    public class ShopPanelView : ViewBase, IShopPanelView
    {
        [SerializeField] private Canvas _canvas;

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