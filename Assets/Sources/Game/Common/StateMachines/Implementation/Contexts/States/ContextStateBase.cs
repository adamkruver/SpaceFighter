using System.Collections.Generic;
using System.Linq;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.Common.StateMachines.Interfaces;
using Sources.Common.StateMachines.Interfaces.Contexts;
using Sources.Common.StateMachines.Interfaces.Contexts.States;
using Sources.Common.StateMachines.Interfaces.Contexts.Transitions;
using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Implementation.Contexts.States
{
    public class ContextStateBase : StateBase, IContextState
    {
        private readonly List<ITransition> _transitions = new List<ITransition>();

        public void Add(ITransition transition) =>
            _transitions.Add(transition);

        public void Remove(ITransition transition) =>
            _transitions.Remove(transition);

        public void Apply(IPureStateMachine<IContextState> stateMachine, IContext context)
        {
            var transition = _transitions.FirstOrDefault(transition => transition.CanTransit(context));

            if (transition == null)
                return;

            stateMachine.Change(transition.NextState);
        }
    }
}