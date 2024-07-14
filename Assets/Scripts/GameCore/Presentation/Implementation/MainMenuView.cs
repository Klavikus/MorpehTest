using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation
{
    public class MainMenuView : ViewBase, IMainMenuView
    {
        [SerializeField] private Canvas _mainCanvas;

        [field: SerializeField] public Button ToGameloop { get; private set; }

        public void Show() =>
            _mainCanvas.enabled = true;

        public void Hide() =>
            _mainCanvas.enabled = false;
    }
}