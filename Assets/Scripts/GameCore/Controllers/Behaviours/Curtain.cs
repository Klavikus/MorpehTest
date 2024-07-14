using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Modules.Common.Localization;
using UnityEngine;

namespace GameCore.Controllers.Behaviours
{
    public class Curtain : MonoBehaviour, ICurtain
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private LocalizableTMPText _localizableTMPText;
        [SerializeField] private Transform _tweenContainer;

        [SerializeField] private float _alphaStep;
        [SerializeField] private float _tweenScale;
        [SerializeField] private float _tweenDuration;

        private readonly CancellationTokenSource _cancellationTokenSource = new();

        private bool _inProgress;
        private bool _isShowed;
        private Tween _tween;

        public void Initialize()
        {
            _canvas.enabled = false;
            _canvasGroup.alpha = 0;
            DontDestroyOnLoad(gameObject);
            _tween = _tweenContainer.DOScale(_tweenScale, _tweenDuration).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
            _tween.Pause();
        }

        public void SetText(string localizedText) =>
            _localizableTMPText.SetValue(localizedText);

        public void InstantShow()
        {
            _tween.Play();

            _canvas.enabled = true;
            _canvasGroup.alpha = 1;
            _isShowed = true;
        }

        public async UniTask Show()
        {
            if (_inProgress || _isShowed)
                return;

            _tween.Play();

            _inProgress = true;

            _canvas.enabled = true;

            while (_canvasGroup.alpha < 1 && _cancellationTokenSource.IsCancellationRequested == false)
            {
                _canvasGroup.alpha += _alphaStep * Time.deltaTime;

                await UniTask.Yield(_cancellationTokenSource.Token);
            }

            _canvasGroup.alpha = 1;
            _inProgress = false;
            _isShowed = true;
        }

        public async UniTask Hide()
        {
            if (_inProgress || _isShowed == false)
                return;

            _tween.Pause();

            _inProgress = true;

            while (_canvasGroup.alpha > 0 && _cancellationTokenSource.IsCancellationRequested == false)
            {
                _canvasGroup.alpha -= _alphaStep * Time.deltaTime;
                await UniTask.Yield(_cancellationTokenSource.Token);
            }

            _canvasGroup.alpha = 0;
            _canvas.enabled = false;
            _inProgress = false;
            _isShowed = false;
        }

        private void OnDestroy()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();

            _tween?.Kill();
        }
    }
}