namespace Modules.Infrastructure.Interfaces
{
    public interface ITickUpdateService
    {
        void Register(IUpdatable updatable);
        void Unregister(IUpdatable updatable);
    }
}