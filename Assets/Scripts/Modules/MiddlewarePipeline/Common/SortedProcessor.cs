using Runtime.Features.MiddlewarePipeline.Interfaces;

namespace Runtime.Features.MiddlewarePipeline.Common
{
    public readonly struct SortedProcessor<TOutValue> : IMiddlewareProcessor<TOutValue>
    {
        public void Process(in MiddlewareCollection<IMiddleware<TOutValue>> collection, ref TOutValue outValue)
        {
            var next = collection.First;

            while (next != null)
            {
                next.Process(ref outValue);
                next = (IMiddleware<TOutValue>) next.Next;
            }
        }
    }    
    
    public readonly struct SortedProcessor<TInput, TOutValue> : IMiddlewareProcessor<TInput, TOutValue>
    {
        public void Process(in MiddlewareCollection<IMiddleware<TInput, TOutValue>> collection, in TInput input, ref TOutValue outValue)
        {
            var next = collection.First;

            while (next != null)
            {
                next.Process(input, ref outValue);
                next = (IMiddleware<TInput, TOutValue>) next.Next;
            }
        }
    }
}