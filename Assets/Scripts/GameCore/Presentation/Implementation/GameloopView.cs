using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation
{
    public class GameloopView : ViewBase, IGameloopView
    {
        [SerializeField] private Canvas _mainCanvas;

        [field: SerializeField] public Button ToMainMenu { get; private set; }

        public void Show() =>
            _mainCanvas.enabled = true;

        public void Hide() =>
            _mainCanvas.enabled = false;
    }
}