using Sources.Interfaces.Infrastructure.States;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters
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