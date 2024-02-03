using Sources.Game.Interfaces.SpaceshipStates;

namespace Sources.Game.Implementation.Controllers
{
	public interface ISpaceshipService
	{
		void ChangeSpaceshipState<TState>() where TState : ISpaceshipState;
	}
}