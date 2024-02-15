using Sources.Common.StateMachines.Interfaces;
using Sources.Common.StateMachines.Interfaces.Contexts;
using Sources.Common.StateMachines.Interfaces.Contexts.States;
using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Implementation.Contexts
{
    public class ContextStateMachine : PureStateMachine<IContextState>, IStateMachine<IContextState>,
        IContextStateMachine
    {
        public IContextState FirstState { get; set; }
        public IContextState CurrentState => State;

        public void Run() =>
            Change(FirstState);

        public void Stop() =>
            Change(null);

        public void Apply(IContext context) =>
            State.Apply(this, context);
    }
}