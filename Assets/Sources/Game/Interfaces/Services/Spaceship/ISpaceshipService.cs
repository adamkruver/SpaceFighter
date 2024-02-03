using Sources.Game.Interfaces.SpaceshipStates;

namespace Sources.Game.Interfaces.Services.Spaceship
{
	public interface ISpaceshipService
	{
		void ChangeSpaceshipState<TState>() where TState : ISpaceshipState;
	}
}