using Sources.Interfaces.Infrastructure.States;

namespace Sources.Interfaces.Infrastructure.StateMachine
{
	public interface IStateMachine<T> where T : class, IState
	{
		public T CurrentState { get; }

		public void Change(T state);
	}
}