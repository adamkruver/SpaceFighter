using Sources.Implementation.Infrastructure.StateMachines;
using Sources.Interfaces.Infrastructure.StateMachine;
using Sources.Interfaces.Infrastructure.States;

namespace Sources.Implementation.Infrastructure.Factories
{
	public class StateMachineFactory
	{
		public IStateMachine<T> Create<T>() where T : class, IState =>
			new StateMachine<T>();
	}
}