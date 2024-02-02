namespace Sources.Game.Implementation.Controllers
{
	public interface ISpaceshipServiceFactory
	{
		ISpaceshipService Create();
	}
}