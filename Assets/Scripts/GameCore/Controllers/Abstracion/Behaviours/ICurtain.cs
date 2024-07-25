using Cysharp.Threading.Tasks;

namespace GameCore.Controllers.Abstracion.Behaviours
{
    public interface ICurtain
    {
        void Initialize();
        void SetText(string localizedText);
        void InstantShow();
        UniTask Show();
        UniTask Hide();
    }
}