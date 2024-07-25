using System.Collections.Generic;
using GameCore.Domain.Enums;

namespace GameCore.Controllers.Implementation.Services
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
    }
}