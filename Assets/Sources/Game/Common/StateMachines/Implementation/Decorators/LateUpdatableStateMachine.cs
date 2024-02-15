using System;
using Sources.Common.StateMachines.Interfaces;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Implementation.Decorators
{
    public class LateUpdatableStateMachine<T> : IStateMachine<T>, ILateUpdateHandler where T : class, IState
    {
        private readonly IStateMachine<T> _stateMachine;

        public LateUpdatableStateMachine(IStateMachine<T> stateMachine) =>
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

        public T CurrentState => _stateMachine.CurrentState;

        public void Change(T state) =>
            _stateMachine.Change(state);

        public void UpdateLate(float deltaTime) =>
            (CurrentState as ILateUpdateHandler)?.UpdateLate(deltaTime);
    }
}