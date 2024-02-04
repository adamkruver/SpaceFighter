using System;
using Sources.Interfaces.Infrastructure.Handlers;
using Sources.Interfaces.Infrastructure.StateMachine;
using Sources.Interfaces.Infrastructure.States;

namespace Sources.Implementation.Infrastructure.StateMachines.Decorators
{
    public class StateMachineLateUpdatable<T> : IStateMachine<T>, ILateUpdateHandler where T : class, IState
    {
        private readonly IStateMachine<T> _stateMachine;

        public StateMachineLateUpdatable(IStateMachine<T> stateMachine) =>
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

        public T CurrentState => _stateMachine.CurrentState;

        public void Change(T state) =>
            _stateMachine.Change(state);

        public void UpdateLate(float deltaTime) =>
            (CurrentState as ILateUpdateHandler)?.UpdateLate(deltaTime);
    }
}