using System;
using Modules.UI.UIComponents.Runtime.Implementations.Tweens;
using Modules.UI.UIComponents.Runtime.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.UI.UIComponents.Runtime.Implementations.Buttons
{
    public class ActionButton : MonoBehaviour, IActionButton
    {
        [SerializeField] private Button _button;
        [SerializeField] private bool _upAndDown;

        [SerializeField] private TweenAction _actionComponent;
        [SerializeField] private TweenAction _focusActionComponent;

        public event Action Clicked;

        private bool _isInteractionLocked;

        private bool _clickActionExist;
        private bool _focusActionExist;

        private void OnEnable() =>
            _button.onClick.AddListener(OnButtonClicked);

        private void OnDestroy() =>
            _button.onClick.RemoveListener(OnButtonClicked);

        public void Initialize()
        {
            if (_actionComponent != null)
            {
                _clickActionExist = true;
                _actionComponent.Initialize();
            }

            if (_focusActionComponent != null)
            {
                _focusActionExist = true;
                _focusActionComponent.Initialize();
            }
        }

        public void SetInteractionLock(bool isLock)
        {
            _button.interactable = isLock == false;
            _isInteractionLocked = isLock;
        }

        private async void OnButtonClicked()
        {
            if (_isInteractionLocked)
                return;

            _isInteractionLocked = true;

            if (_clickActionExist == false)
            {
                Clicked?.Invoke();
                _isInteractionLocked = false;

                return;
            }

            await _actionComponent.PlayForward();

            if (_upAndDown == false)
            {
                _isInteractionLocked = false;

                Clicked?.Invoke();
                _actionComponent.SetBackwardState();

                return;
            }

            await _actionComponent.PlayBackward();

            _isInteractionLocked = false;

            Clicked?.Invoke();
        }

        public void Focus()
        {
            if (_focusActionExist == false)
                return;

            _focusActionComponent.PlayForward();
        }

        public void Unfocus()
        {
            if (_focusActionExist == false)
                return;

            _focusActionComponent?.Cancel();
            _focusActionComponent?.PlayBackward();
        }
    }
}