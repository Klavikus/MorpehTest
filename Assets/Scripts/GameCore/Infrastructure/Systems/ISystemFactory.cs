namespace GameCore.Infrastructure.Systems
{
    public interface ISystemFactory
    {
        T Create<T>();
    }
}