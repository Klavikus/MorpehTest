using Cysharp.Threading.Tasks;

namespace GameCore.Controllers.Behaviours
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