using System;
using Sources.Common.StateMachines.Interfaces.Contexts;
using Sources.Common.StateMachines.Interfaces.Contexts.Generic;
using Sources.Common.StateMachines.Interfaces.Contexts.States;
using Sources.Common.StateMachines.Interfaces.Contexts.Transitions;
using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Implementation.Contexts.Transitions
{
    public class Transition<T> : ITransition
    {
        private readonly Predicate<T> _canTransit;

        public Transition(Predicate<T> canTransit, IContextState nextState)
        {
            NextState = nextState ?? throw new ArgumentNullException(nameof(nextState));
            _canTransit = canTransit ?? throw new ArgumentNullException(nameof(canTransit));
        }

        public IContextState NextState { get; }
        
        public bool CanTransit(IContext context)
        {
            if(context is not IContext<T> concreteContext)
                return false;

            return CanTransit(concreteContext.Value);
        }

        private bool CanTransit(T context) => 
            _canTransit.Invoke(context);
    }
}