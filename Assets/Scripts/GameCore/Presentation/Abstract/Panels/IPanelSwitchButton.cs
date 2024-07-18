using System;
using GameCore.Controllers.Enums;

namespace GameCore.Presentation.Abstract.Panels
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