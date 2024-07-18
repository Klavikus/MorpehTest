using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;

namespace Modules.Infrastructure.Interfaces.GameFsm
{
    public interface IGameStateMachine
    {
        void Enter<TState>()
            where TState : class, IState;

        void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPayloadState<TPayload>
            where TPayload : SceneData;

        void Update();
        void RegisterState(IExitableState state);
    }
}