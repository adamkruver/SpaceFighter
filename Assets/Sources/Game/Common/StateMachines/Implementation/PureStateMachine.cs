using Sources.Common.StateMachines.Interfaces;
using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Implementation
{
    public class PureStateMachine <T> : IPureStateMachine<T> where T: class, IState
    {
        protected T State { get; private set; }

        public void Change(T state)
        {
            State?.Exit();
            State = state;
            State?.Enter();
        }
    }
}