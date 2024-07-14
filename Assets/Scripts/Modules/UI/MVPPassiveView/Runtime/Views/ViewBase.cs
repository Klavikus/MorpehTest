using System;
using Modules.UI.MVPPassiveView.Runtime.Presenters;
using UnityEngine;

namespace Modules.UI.MVPPassiveView.Runtime.Views
{
    public abstract class ViewBase : MonoBehaviour, IView
    {
        private IPresenter _presenter;

        public void Construct(IPresenter presenter)
        {
            if (presenter == null)
                throw new ArgumentNullException(nameof(presenter));

            gameObject.SetActive(false);
            OnBeforeConstruct();
            _presenter = presenter;
            OnAfterConstruct();
            gameObject.SetActive(true);
        }

        public void Destroy() =>
            Destroy(gameObject);

        protected virtual void OnBeforeConstruct()
        {
        }

        protected virtual void OnAfterConstruct()
        {
        }

        protected virtual void OnBeforeDestroy()
        {
        }

        private void OnEnable() =>
            _presenter?.Enable();

        private void OnDisable() =>
            _presenter?.Disable();

        private void OnDestroy() =>
            OnBeforeDestroy();
    }
}