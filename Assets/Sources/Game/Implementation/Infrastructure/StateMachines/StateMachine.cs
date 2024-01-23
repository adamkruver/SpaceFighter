using Sources.Game.Interfaces.Infrastructure.StateMachine;
using Sources.Game.Interfaces.Infrastructure.States;

namespace Sources.Game.Implementation.Infrastructure.StateMachines
{
	public sealed class StateMachine<T> : IStateMachine<T> where T : class, IState
	{
		private T _currentState;

		public T CurrentState => _currentState;

		public void Change(T state)
		{
			_currentState?.Exit();
			_currentState = state;
			_currentState?.Enter();
		}
	}
}