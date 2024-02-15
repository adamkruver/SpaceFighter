using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Implementation.States
{
    public class StateBase : IState
    {
        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }
    }
}