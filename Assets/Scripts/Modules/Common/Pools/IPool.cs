namespace Modules.Common.Pools
{
    public interface IPool
    {
        void Release(IPoolable poolable);
        void Clear();
        bool TryGet(out IPoolable poolable);
    }
}