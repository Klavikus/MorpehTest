using System.Collections.Generic;
using Runtime.Features.MiddlewarePipeline.Interfaces;

namespace Runtime.Features.MiddlewarePipeline.Common
{
    public class MiddlewarePipelineStorage
    {
        private readonly Dictionary<int, MiddlewarePipeline> _storage = new(8);

        public MiddlewarePipeline<TOutValue, TProcessor> Get<TOutValue, TProcessor>(int id)
            where TProcessor : struct, IMiddlewareProcessor<TOutValue>
        {
            return (MiddlewarePipeline<TOutValue, TProcessor>) _storage[id];
        }

        public bool TryGet<TOutValue, TProcessor>(int id, out MiddlewarePipeline<TOutValue, TProcessor> pipeline)
            where TProcessor : struct, IMiddlewareProcessor<TOutValue>
        {
            pipeline = null;

            if (_storage.ContainsKey(id) == false)
                return false;

            pipeline = Get<TOutValue, TProcessor>(id);
            return true;
        }

        public void Add(int id, MiddlewarePipeline pipeline)
        {
            _storage.Add(id, pipeline);
        }

        public bool Contains(int id)
        {
            return _storage.ContainsKey(id);
        }
    }
}