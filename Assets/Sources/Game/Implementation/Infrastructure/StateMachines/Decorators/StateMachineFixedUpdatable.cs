using System;
using Sources.Implementation.Services.Lifecycles;
using Sources.Interfaces.Infrastructure.StateMachine;
using Sources.Interfaces.Infrastructure.States;

namespace Sources.Implementation.Infrastructure.StateMachines.Decorators
{
    public class StateMachineFixedUpdatable<T> : IStateMachine<T>, IFixedUpdateHandler where T : class, IState
    {
        private readonly IStateMachine<T> _stateMachine;

        public StateMachineFixedUpdatable(IStateMachine<T> stateMachine) =>
            _stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));

        public T CurrentState => _stateMachine.CurrentState;

        public void Change(T state) =>
            _stateMachine.Change(state);

        public void UpdateFixed(float deltaTime) =>
            (CurrentState as IFixedUpdateHandler)?.UpdateFixed(deltaTime);
    }
}