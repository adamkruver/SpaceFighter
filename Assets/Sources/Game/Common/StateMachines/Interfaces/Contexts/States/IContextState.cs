using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Interfaces.Contexts.States
{
    public interface IContextState : IState
    {
        void Apply(IPureStateMachine<IContextState> stateMachine, IContext context);
    }
}