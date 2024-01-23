using Sources.Game.Interfaces.Infrastructure.States;

namespace Sources.Game.Interfaces.Infrastructure.StateMachine
{
	public interface IStateMachine<T> where T : class, IState
	{
		public T CurrentState { get; }

		public void Change(T state);
	}
}