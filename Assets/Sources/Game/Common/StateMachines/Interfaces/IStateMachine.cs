using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Interfaces
{
	public interface IStateMachine<T> : IPureStateMachine<T> where T : class, IState
	{
		public T CurrentState { get; }
	}
}