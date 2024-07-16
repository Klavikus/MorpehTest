using System;
using GameCore.Controllers;

namespace GameCore.Presentation.Abstract
{
    public interface IPanelSwitchButton
    {
        event Action<IPanelSwitchButton> Clicked;
        PanelType PanelType { get; }
        void Initialize();
        void SetLabelText(string text);
        void Focus();
        void Unfocus();
    }
}