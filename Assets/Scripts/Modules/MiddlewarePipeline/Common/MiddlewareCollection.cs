using System;
using Runtime.Features.MiddlewarePipeline.Interfaces;

namespace Runtime.Features.MiddlewarePipeline.Common
{
    public class MiddlewareCollection 
    {
        public int Count { get; protected set; }
    }
    
    public class MiddlewareCollection<TMiddleware> : MiddlewareCollection, IMiddlewareCollection<TMiddleware>
        where TMiddleware : class, IMiddleware
    {
        internal TMiddleware First { get; private set; }

        internal TMiddleware Last { get; private set; }

        public int Count { get; private set; }

        public void Add(TMiddleware middleware)
        {
            Count++;

            if (First == null)
            {
                First = middleware;
                return;
            }

            if (Last == null)
            {
                First.Next = middleware;
                Last = middleware;

                return;
            }

            if (Last != null)
                Last.Next = middleware;

            Last = middleware;
        }

        public void Remove(TMiddleware middleware)
        {
            var next = First;

            while (next != null)
            {
                if (next == middleware)
                {
                    var previous = next.Previous;
                    previous.Next = next.Next;
                    Count--;

                    return;
                }

                next = (TMiddleware) next.Next;
            }

#if UNITY_EDITOR
            throw new NullReferenceException("Middleware");
#endif
        }
    }
}