using System;
using GameCore.Presentation.Abstract;
using Modules.UI.UIComponents.Runtime.Implementations.Buttons;
using TMPro;
using UnityEngine;

namespace GameCore.Presentation.Implementation.MainMenu
{
    public class PanelSwitchButton : MonoBehaviour, IPanelSwitchButton
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private ActionButton _actionButton;

        public event Action<IPanelSwitchButton> Clicked;

        private bool _inFocus;

        public void Initialize()
        {
            _actionButton.Initialize();
            _actionButton.Clicked += OnActionButtonClicked;
        }

        private void OnDestroy()
        {
            _actionButton.Clicked -= OnActionButtonClicked;
        }

        public void SetLabelText(string text) =>
            _label.text = text;

        public void Focus()
        {
            if (_inFocus)
                return;

            _inFocus = true;

            _actionButton.Focus();
        }

        public void Unfocus()
        {
            if (_inFocus == false)
                return;

            _inFocus = false;
            
            _actionButton.Unfocus();
        }

        private void OnActionButtonClicked() =>
            Clicked?.Invoke(this);
    }
}