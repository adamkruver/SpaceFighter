using Sources.Common.StateMachines.Interfaces.States;

namespace Sources.BoundedContexts.Torques.Implementation.Presenters
{
	public abstract class StateBase : IState
	{
		public virtual void Enter()
		{
		}

		public virtual void Exit()
		{
		}
	}
}