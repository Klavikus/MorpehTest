using Modules.MiddlewarePipeline.Common;

namespace Modules.MiddlewarePipeline.Interfaces
{
    public interface IMiddlewareProcessor<TOutValue>
    {
        public void Process(in MiddlewareCollection<IMiddleware<TOutValue>> collection, ref TOutValue outValue);
    }

    public interface IMiddlewareProcessor<TInput, TOutValue>
    {
        public void Process(
            in MiddlewareCollection<IMiddleware<TInput, TOutValue>> collection,
            in TInput input,
            ref TOutValue outValue);
    }
}