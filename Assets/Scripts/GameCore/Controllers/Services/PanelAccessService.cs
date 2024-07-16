using System.Collections.Generic;

namespace GameCore.Controllers.Services
{
    public class PanelAccessService : IPanelAccessService
    {
        private readonly Stack<WindowType> _allowedWindows;

        public PanelAccessService()
        {
            _allowedWindows = new Stack<WindowType>();
            _allowedWindows.Push(WindowType.FightPanel);
            _allowedWindows.Push(WindowType.ShopPanel);
        }

        public bool CheckAllowStatus(WindowType windowType) =>
            _allowedWindows.Contains(windowType);
    }
}