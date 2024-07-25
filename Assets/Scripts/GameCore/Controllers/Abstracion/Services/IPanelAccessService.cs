using GameCore.Domain.Enums;

namespace GameCore.Controllers.Implementation.Services
{
    public interface IPanelAccessService
    {
        bool CheckAllowStatus(PanelType panelType);
    }
}