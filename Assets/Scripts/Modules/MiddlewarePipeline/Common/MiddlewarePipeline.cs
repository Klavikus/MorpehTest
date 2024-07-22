using Runtime.Features.MiddlewarePipeline.Interfaces;

namespace Runtime.Features.MiddlewarePipeline.Common
{
    public class MiddlewarePipeline
    {
        
    }
    
    public class MiddlewarePipeline<TOutValue, TProcessor> : MiddlewarePipeline, IMiddlewarePipeline<TOutValue, TProcessor>
        where TProcessor : struct, IMiddlewareProcessor<TOutValue>
    {
        private readonly MiddlewareCollection<IMiddleware<TOutValue>> _collection = new();
        
        public void Add(IMiddleware<TOutValue> middleware)
        {
            _collection.Add(middleware);
        }
        
        public void Process(ref TOutValue outValue)
        {
            new TProcessor().Process(_collection, ref outValue);
        }

        public T Get<T>() where T : class, IMiddleware<TOutValue>
        {
            var current = _collection.First;

            while (current != null)
            {
                if (current is T middleware)
                    return middleware;

                if (current.Next == null)
                    return null;
                
                current = (IMiddleware<TOutValue>) current.Next;
            }

            return null;
        }

        public void Remove(IMiddleware<TOutValue> middleware)
        {
            _collection.Remove(middleware);
        }
    }    
    
    public class MiddlewarePipeline<TInput, TOutValue, TProcessor> : IMiddlewarePipeline<TInput, TOutValue, TProcessor>
        where TProcessor : struct, IMiddlewareProcessor<TInput, TOutValue>
    {
        private readonly MiddlewareCollection<IMiddleware<TInput, TOutValue>> _collection = new();
        
        public void Add(IMiddleware<TInput, TOutValue> middleware)
        {
            _collection.Add(middleware);
        }

        public void Process(in TInput input, ref TOutValue outValue)
        {
            new TProcessor().Process(_collection, input, ref outValue);
        }
        
        public void Remove(IMiddleware<TInput, TOutValue> middleware)
        {
            _collection.Remove(middleware);
        }
    }
}