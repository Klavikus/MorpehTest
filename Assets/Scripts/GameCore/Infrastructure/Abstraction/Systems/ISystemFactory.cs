namespace GameCore.Infrastructure.Abstraction.Systems
{
    public interface ISystemFactory
    {
        T Create<T>();
    }
}