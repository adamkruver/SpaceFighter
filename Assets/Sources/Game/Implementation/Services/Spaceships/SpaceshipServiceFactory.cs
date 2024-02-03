using Sources.Game.Interfaces.Services.Spaceship;

namespace Sources.Game.Implementation.Services.Spaceships
{
	public class SpaceshipServiceFactory : ISpaceshipServiceFactory
	{
		public SpaceshipServiceFactory()
		{
			
		}

		public ISpaceshipService Create()
		{
			
			return new SpaceshipService();
		}
	}
}