namespace Sources.Game.Implementation.Controllers
{
	public interface ISpaceshipService
	{
		void ChangeSpaceshipState<TState>() where TState : ISpaceshipState;
	}
}