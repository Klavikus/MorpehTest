using System.Collections.Generic;

namespace Modules.Common.Pools
{
    public class Pool : IPool
    {
        private readonly Queue<object> _items = new();

        public bool TryGet(out IPoolable poolable)
        {
            poolable = null;

            if (_items.Count == 0)
                return false;

            poolable = _items.Dequeue() as IPoolable;

            return true;
        }

        public void Release(IPoolable poolable) =>
            _items.Enqueue(poolable);

        public void Clear() =>
            _items.Clear();
    }
}