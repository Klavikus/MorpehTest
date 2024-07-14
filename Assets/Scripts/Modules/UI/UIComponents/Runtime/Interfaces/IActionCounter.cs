using System;

namespace Modules.UI.UIComponents.Runtime.Interfaces
{
    public interface IActionCounter
    {
        event Action CountStarted;
        event Action CountCompleted;
        void Initialize(float initialValue);
        void Count(float targetValue);
    }
}