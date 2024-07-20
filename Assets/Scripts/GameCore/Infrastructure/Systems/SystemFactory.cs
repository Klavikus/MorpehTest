using VContainer;

namespace Code.Infrastructure.Systems
{
    public class SystemFactory : ISystemFactory
    {
        private readonly IObjectResolver _diContainer;

        public SystemFactory(IObjectResolver diContainer) =>
            _diContainer = diContainer;

        public T Create<T>() =>
            _diContainer.Resolve<T>();
    }
}