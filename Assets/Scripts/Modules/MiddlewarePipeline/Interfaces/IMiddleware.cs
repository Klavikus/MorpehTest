using VContainer;

namespace Modules.MiddlewarePipeline.Interfaces
{
    public interface IMiddleware
    {
        public IMiddleware Next { get; set; }

        public IMiddleware Previous { get; set; }

        public void Init(IObjectResolver resolver);
    }

    public interface IMiddleware<TOutValue> : IMiddleware
    {
        public void Process(ref TOutValue outValue);
    }

    public interface IMiddleware<in TInput, TOutValue> : IMiddleware
    {
        public void Process(TInput input, ref TOutValue outValue);
    }
}