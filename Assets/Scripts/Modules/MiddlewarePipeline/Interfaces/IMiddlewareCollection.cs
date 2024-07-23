namespace Modules.MiddlewarePipeline.Interfaces
{
    public interface IMiddlewareCollection<TMiddleware> 
        where TMiddleware : IMiddleware
    {
        public void Add(TMiddleware middleware);

        public void Remove(TMiddleware middleware);
    }
}