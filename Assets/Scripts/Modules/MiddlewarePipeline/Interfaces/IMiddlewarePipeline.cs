namespace Runtime.Features.MiddlewarePipeline.Interfaces
{
    public interface IMiddlewarePipeline<TOutValue, TProcessor> : IMiddlewareCollection<IMiddleware<TOutValue>>
        where TProcessor : struct, IMiddlewareProcessor<TOutValue>
    {
        public void Process(ref TOutValue outValue);

        public T Get<T>() where T : class, IMiddleware<TOutValue>;
    }

    public interface IMiddlewarePipeline<TInput, TOutValue, TProcessor> : IMiddlewareCollection<IMiddleware<TInput, TOutValue>>
        where TProcessor : struct, IMiddlewareProcessor<TInput, TOutValue>
    {
        public void Process(in TInput input, ref TOutValue outValue);
    }
}