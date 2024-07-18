using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation.MainMenu
{
    public class FightPanelView : ViewBase, IFightPanelView
    {
        [SerializeField] private Canvas _canvas;
        [field: SerializeField] public Button StartButton { get; private set; }

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