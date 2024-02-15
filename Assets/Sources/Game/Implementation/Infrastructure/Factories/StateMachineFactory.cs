using Sources.Common.StateMachines.Implementation;
using Sources.Common.StateMachines.Interfaces;
using Sources.Common.StateMachines.Interfaces.States;
using Sources.Interfaces.Infrastructure.StateMachine;

namespace Sources.Implementation.Infrastructure.Factories
{
	public class StateMachineFactory
	{
		public IStateMachine<T> Create<T>() where T : class, IState =>
			new StateMachine<T>();
	}
}