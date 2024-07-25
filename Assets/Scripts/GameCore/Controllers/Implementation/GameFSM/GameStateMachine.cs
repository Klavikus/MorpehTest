using System;
using System.Collections.Generic;
using Modules.Infrastructure.Interfaces.GameFsm;
using Qw1nt.Runtime.Shared.AddressablesContentController.SceneManagement;

namespace GameCore.Controllers.Implementation.GameFSM
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states = new();

        private IExitableState _activeState;
        private IExitableState _nextState;

        public void RegisterState(IExitableState state) =>
            _states.Add(state.GetType(), state);

        public void Enter<TState>()
            where TState : class, IState
        {
            TState targetState = GetState<TState>();

            if (_activeState == targetState || _nextState == targetState)
                return;

            _nextState = targetState;

            ChangeState(targetState);
        }

        public void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPayloadState<TPayload>
            where TPayload : SceneData
        {
            TState targetState = GetState<TState>();

            if (_activeState == targetState || _nextState == targetState)
                return;

            _nextState = targetState;

            ChangeState(targetState, payload);
        }

        public void Update() =>
            _activeState.Update();

        private void ChangeState(IState state)
        {
            if (_activeState != null)
                _activeState.Exit();

            _activeState = state;
            state.Enter();
        }

        private void ChangeState<TPayload>(IPayloadState<TPayload> state, TPayload payload)
            where TPayload : SceneData
        {
            if (_activeState != null)
                _activeState.Exit();

            _activeState = state;
            state.Enter(payload);
        }

        private TState GetState<TState>()
            where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}