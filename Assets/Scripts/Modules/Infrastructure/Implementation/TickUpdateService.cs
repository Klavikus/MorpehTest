using System.Collections.Generic;
using Modules.Infrastructure.Interfaces;
using UnityEngine;

namespace Modules.Infrastructure.Implementation
{
    public class TickUpdateService : MonoBehaviour, ITickUpdateService
    {
        private readonly List<IUpdatable> _updatables = new();
        private readonly List<IUpdatable> _forUnregister = new();

        private bool _isUnregisterRequested;

        public void Register(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }

        public void Unregister(IUpdatable updatable)
        {
            if (_updatables.Contains(updatable) == false)
                return;

            _isUnregisterRequested = true;

            _forUnregister.Add(updatable);
        }

        private void Update()
        {
            foreach (IUpdatable updatable in _updatables)
                updatable.Update(Time.deltaTime);

            if (_isUnregisterRequested == false)
                return;

            foreach (IUpdatable updatable in _forUnregister)
                _updatables.Remove(updatable);

            _forUnregister.Clear();

            _isUnregisterRequested = false;
        }
    }
}