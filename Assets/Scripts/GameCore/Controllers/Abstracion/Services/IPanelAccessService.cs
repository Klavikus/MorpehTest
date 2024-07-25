using GameCore.Domain.Enums;

namespace GameCore.Controllers.Abstracion.Services
{
    public interface IPanelAccessService
    {
        bool CheckAllowStatus(PanelType panelType);
    }
}