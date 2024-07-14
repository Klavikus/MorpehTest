using Cysharp.Threading.Tasks;

namespace Modules.UI.UIComponents.Runtime.Interfaces
{
    public interface ITweenAction
    {
        void Initialize();
        void Cancel();
        UniTask PlayForward();
        UniTask PlayBackward();
        void SetForwardState();
        void SetBackwardState();
    }
}