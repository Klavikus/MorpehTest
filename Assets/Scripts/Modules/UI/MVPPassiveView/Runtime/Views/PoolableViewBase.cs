using System;
using Modules.Common.Pools;
using Modules.UI.MVPPassiveView.Runtime.Presenters;
using UnityEngine;

namespace Modules.UI.MVPPassiveView.Runtime.Views
{
    public abstract class PoolableViewBase : MonoBehaviour, IPoolable
    {
        private IPresenter _presenter;
        private IPool _pool;

        public void Construct(IPresenter presenter, IPool pool)
        {
            if (presenter == null)
                throw new ArgumentNullException(nameof(presenter));

            _pool = pool ?? throw new ArgumentNullException(nameof(pool));

            gameObject.SetActive(false);
            OnBeforeConstruct();
            _presenter = presenter;
            OnAfterConstruct();
            gameObject.SetActive(true);
        }

        public void Destroy()
        {
            if (_pool != null)
            {
                BackToPool();

                return;
            }

            Destroy(gameObject);
        }

        public void BackToPool()
        {
            if (_pool == null)
                throw new Exception("You trying to release poolable, but poolable without pool!");

            gameObject.SetActive(false);
            _pool.Release(this);
        }

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