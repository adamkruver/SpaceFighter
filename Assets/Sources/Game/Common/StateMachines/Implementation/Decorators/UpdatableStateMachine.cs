using System;
using Sources.Common.StateMachines.Interfaces;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Implementation.Decorators
{
    public class UpdatableStateMachine<T> : IStateMachine<T>, IUpdateHandler where T : class, IState
    {
        private readonly IStateMachine<T> _stateMachine;

        public UpdatableStateMachine(IStateMachine<T> stateMachine) =>
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

        public T CurrentState => _stateMachine.CurrentState;

        public void Change(T state) =>
            _stateMachine.Change(state);

        public void Update(float deltaTime) =>
            (CurrentState as IUpdateHandler)?.Update(deltaTime);
    }
}