using Sources.Game.Interfaces.SpaceshipStates;

namespace Sources.Game.Interfaces.Services.Spaceship
{
	public interface ISpaceshipService
	{
		void ChangeState<TState>() where TState : ISpaceshipState;
	}
}