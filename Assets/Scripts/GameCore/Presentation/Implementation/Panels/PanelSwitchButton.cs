using System;
using GameCore.Controllers.Enums;
using GameCore.Presentation.Abstract.Panels;
using Modules.UI.UIComponents.Runtime.Implementations.Buttons;
using TMPro;
using UnityEngine;

namespace GameCore.Presentation.Implementation.Panels
{
    public class PanelSwitchButton : MonoBehaviour, IPanelSwitchButton
    {
        [SerializeField] private TMP_Text _label;
        [SerializeField] private ActionButton _actionButton;

        private bool _inFocus;
        public event Action<IPanelSwitchButton> Clicked;

        [field: SerializeField] public PanelType PanelType { get; private set; }

        public void Initialize()
        {
#if DEBUG
            if (PanelType == PanelType.None)
                throw new Exception($"{nameof(PanelType)} can't be {PanelType.None}, select another type!");
#endif

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