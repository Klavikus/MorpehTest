using Cysharp.Threading.Tasks;

namespace GameCore.Controllers.Services
{
    public interface ICurtainService
    {
        UniTask Initialize();
        UniTask Show();
        UniTask Hide();
    }
}