namespace GameCore.Controllers.Services
{
    public interface IPanelAccessService
    {
        bool CheckAllowStatus(WindowType windowType);
    }
}