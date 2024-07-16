using System;

namespace GameCore.Presentation.Abstract
{
    public interface IPanelSwitchButton
    {
        event Action<IPanelSwitchButton> Clicked;
        void Initialize();
        void SetLabelText(string text);
        void Focus();
        void Unfocus();
    }
}