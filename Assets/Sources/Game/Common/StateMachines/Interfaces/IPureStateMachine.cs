using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Interfaces
{
    public interface IPureStateMachine<in T> where T : class, IState
    {
        public void Change(T state);
    }
}