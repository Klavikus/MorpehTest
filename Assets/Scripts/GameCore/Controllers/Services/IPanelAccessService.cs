using GameCore.Controllers.Enums;

namespace GameCore.Controllers.Services
{
    public interface IPanelAccessService
    {
        bool CheckAllowStatus(PanelType panelType);
    }
}