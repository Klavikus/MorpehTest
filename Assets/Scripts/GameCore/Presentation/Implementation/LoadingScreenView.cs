using DG.Tweening;
using GameCore.Presentation.Abstract;
using Modules.UI.MVPPassiveView.Runtime.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore.Presentation.Implementation
{
    public class LoadingScreenView : ViewBase, ILoadingScreenView
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TMP_Text _localizableTMPText;
        [SerializeField] private Transform _tweenContainer;
        [SerializeField] private Slider _slider;

        [SerializeField] private float _tweenScale;
        [SerializeField] private float _tweenDuration;

        private Tween _tween;

        public void Initialize()
        {
            _canvas.enabled = false;
            _tween = _tweenContainer.DOScale(_tweenScale, _tweenDuration).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
            _tween.Pause();
        }

        public void Fill(float progress, string description)
        {
            _slider.value = progress;
            _localizableTMPText.text = description;
        }

        public void Show()
        {
            _tween.Play();

            _canvas.enabled = true;
        }

        public void Hide()
        {
            _tween.Pause();

            _canvas.enabled = false;
        }

        private void OnDestroy()
        {
            _tween?.Kill();
        }
    }
}