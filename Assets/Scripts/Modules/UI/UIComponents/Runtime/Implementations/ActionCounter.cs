using System;
using Modules.UI.UIComponents.Runtime.Interfaces;
using UnityEngine;

namespace Modules.UI.UIComponents.Runtime.Implementations
{
    public abstract class ActionCounter : MonoBehaviour, IActionCounter
    {
        public event Action CountStarted;
        public event Action CountCompleted;

        public abstract void Initialize(float initialValue);
        public abstract void Count(float targetValue);

        protected void InvokeCountStarted() =>
            CountStarted?.Invoke();

        protected void InvokeCountCompleted() =>
            CountCompleted?.Invoke();
    }
}