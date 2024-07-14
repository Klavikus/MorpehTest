using System;

namespace Modules.UI.UIComponents.Runtime.Interfaces
{
    public interface IActionButton
    {
        event Action Clicked;
        void Initialize();
        void SetInteractionLock(bool isLock);
        void Focus();
        void Unfocus();
    }
}