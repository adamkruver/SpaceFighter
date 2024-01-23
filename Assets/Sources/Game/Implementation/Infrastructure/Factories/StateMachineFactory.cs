using Sources.Game.Implementation.Infrastructure.StateMachines;
using Sources.Game.Interfaces.Infrastructure.StateMachine;
using Sources.Game.Interfaces.Infrastructure.States;

namespace Sources.Game.Implementation.Infrastructure.Factories
{
	public class StateMachineFactory
	{
		public IStateMachine<T> Create<T>() where T : class, IState =>
			new StateMachine<T>();
	}
}