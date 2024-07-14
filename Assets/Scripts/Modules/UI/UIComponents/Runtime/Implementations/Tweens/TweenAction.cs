using Cysharp.Threading.Tasks;
using Modules.UI.UIComponents.Runtime.Interfaces;
using UnityEngine;

namespace Modules.UI.UIComponents.Runtime.Implementations.Tweens
{
    public abstract class TweenAction : MonoBehaviour, ITweenAction
    {
        public abstract void Initialize();
        public abstract void Cancel();
        public abstract UniTask PlayForward();
        public abstract UniTask PlayBackward();
        public abstract void SetForwardState();
        public abstract void SetBackwardState();
    }
}