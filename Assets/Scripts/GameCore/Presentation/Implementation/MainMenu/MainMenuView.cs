using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using Modules.UI.UIComponents.Runtime.Implementations.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation.MainMenu
{
    public class MainMenuView : ViewBase, IMainMenuView
    {
        [SerializeField] private Canvas _mainCanvas;
        [SerializeField] private ActionButton[] _actionButtons;

        [field: SerializeField] public Button ToGameloop { get; private set; }

        public void Initialize()
        {
            foreach (ActionButton actionButton in _actionButtons)
            {
                actionButton.Initialize();
            }
        }

        public void Show() =>
            _mainCanvas.enabled = true;

        public void Hide() =>
            _mainCanvas.enabled = false;
    }
}