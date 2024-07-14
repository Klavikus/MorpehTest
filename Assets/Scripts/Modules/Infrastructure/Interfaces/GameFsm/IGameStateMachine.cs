﻿namespace Modules.Infrastructure.Interfaces.GameFsm
{
    public interface IGameStateMachine
    {
        void Enter<TState>()
            where TState : class, IState;

        void Update();
        void RegisterState(IExitableState state);
    }
}