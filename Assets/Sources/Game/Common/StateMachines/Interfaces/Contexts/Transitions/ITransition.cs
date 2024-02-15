using Sources.Common.StateMachines.Interfaces.Contexts.States;
using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Interfaces.Contexts.Transitions
{
    public interface ITransition
    {
        IContextState NextState { get; }
        
        bool CanTransit(IContext context);
    }
}