#if WEB_APPLICATION
using System;
using Agava.WebUtility;
using Modules.FocusHandleSystem.Interfaces;
using Modules.GamePauseSystem.Runtime;
using UnityEngine;

namespace Modules.FocusHandleSystem.Implementation
{
    public class FocusHandler : IFocusHandler
    {
        private readonly IGamePauseService _gamePauseService;

        public FocusHandler(IGamePauseService gamePauseService)
        {
            _gamePauseService = gamePauseService;

            Application.focusChanged += OnFocusChanged;
            WebApplication.InBackgroundChangeEvent += OnBackgroundChanged;
        }

        ~FocusHandler() =>
            ReleaseUnmanagedResources();

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        private void OnBackgroundChanged(bool inBackground) =>
            _gamePauseService.InvokeByFocusChanging(inBackground);

        private void OnFocusChanged(bool inFocus) =>
            _gamePauseService.InvokeByFocusChanging(inFocus == false);

        private void ReleaseUnmanagedResources()
        {
            Application.focusChanged -= OnFocusChanged;
            WebApplication.InBackgroundChangeEvent -= OnBackgroundChanged;
        }
    }
}
#endif