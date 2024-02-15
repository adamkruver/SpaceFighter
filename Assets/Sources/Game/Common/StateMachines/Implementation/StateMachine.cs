using Sources.Common.StateMachines.Interfaces;
using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.Common.StateMachines.Implementation
{
	public sealed class StateMachine<T> : PureStateMachine<T>, IStateMachine<T> where T : class, IState
	{
		public T CurrentState => State;
	}
}