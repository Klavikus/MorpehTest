using System.Collections.Generic;
using GameCore.Controllers.Enums;

namespace GameCore.Controllers.Services
{
    public class PanelAccessService : IPanelAccessService
    {
        private readonly Stack<PanelType> _allowedWindows;

        public PanelAccessService()
        {
            _allowedWindows = new Stack<PanelType>();
            _allowedWindows.Push(PanelType.FightPanel);
            _allowedWindows.Push(PanelType.ShopPanel);
        }

        public bool CheckAllowStatus(PanelType panelType) =>
            true;
        // _allowedWindows.Contains(windowType);
    }
}