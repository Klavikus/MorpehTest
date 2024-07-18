using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;

namespace Modules.Infrastructure.Interfaces.GameFsm
{
    public interface IPayloadState<in T> : IExitableState
        where T : SceneData
    {
        void Enter(T payload);
    }
}