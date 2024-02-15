using System;
using Sources.Common.StateMachines.Interfaces;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Implementation.Decorators
{
    public class FixedUpdatableStateMachine<T> : IStateMachine<T>, IFixedUpdateHandler where T : class, IState
    {
        private readonly IStateMachine<T> _stateMachine;

        public FixedUpdatableStateMachine(IStateMachine<T> stateMachine) =>
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

        public T CurrentState => _stateMachine.CurrentState;

        public void Change(T state) =>
            _stateMachine.Change(state);

        public void UpdateFixed(float deltaTime) =>
            (CurrentState as IFixedUpdateHandler)?.UpdateFixed(deltaTime);
    }
}