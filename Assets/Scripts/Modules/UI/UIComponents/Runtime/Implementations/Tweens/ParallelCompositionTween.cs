using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Modules.UI.UIComponents.Runtime.Implementations.Tweens
{
    public sealed class ParallelCompositionTween : TweenAction
    {
        [SerializeField] private TweenAction[] _tweenActionComponents;
        [SerializeField] private bool _lockDoubleInteraction;
        [SerializeField] private bool _initializeByComposition;

        private UniTask[] _cachedForwardTasks;
        private UniTask[] _cachedBackwardTasks;

        private CancellationTokenSource _cancellationTokenSource;
        private bool _inProgress;

        private void Start()
        {
            if (_initializeByComposition)
                return;

            Initialize();
        }

        private void OnDestroy()
        {
            Cancel();
        }

        public override void Initialize()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            _cachedForwardTasks = new UniTask[_tweenActionComponents.Length];
            _cachedBackwardTasks = new UniTask[_tweenActionComponents.Length];

            foreach (TweenAction actionComponent in _tweenActionComponents) 
                actionComponent.Initialize();
        }

        public override async UniTask PlayForward()
        {
            if (_lockDoubleInteraction && _inProgress)
                return;

            CancelTweens();

            _inProgress = true;

            for (int i = 0; i < _cachedForwardTasks.Length; i++)
                _cachedForwardTasks[i] = _tweenActionComponents[i].PlayForward();

            await UniTask.WhenAll(_cachedForwardTasks);

            _inProgress = false;
        }

        public override async UniTask PlayBackward()
        {
            if (_lockDoubleInteraction && _inProgress)
                return;

            CancelTweens();

            _inProgress = true;
            
            for (int i = 0; i < _cachedBackwardTasks.Length; i++)
                _cachedBackwardTasks[i] = _tweenActionComponents[i].PlayBackward();
            
            await UniTask.WhenAll(_cachedBackwardTasks);

            _inProgress = false;
        }

        public override void Cancel()
        {
            foreach (TweenAction actionComponent in _tweenActionComponents)
                actionComponent.Cancel();

            CancelTweens();

            _inProgress = false;
        }

        public override void SetForwardState()
        {
            foreach (TweenAction actionComponent in _tweenActionComponents)
                actionComponent.SetForwardState();
        }

        public override void SetBackwardState()
        {
            foreach (TweenAction actionComponent in _tweenActionComponents)
                actionComponent.SetBackwardState();
        }

        private void CancelTweens()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = new CancellationTokenSource();
        }
    }
}