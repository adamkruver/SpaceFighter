﻿namespace Sources.Game.Implementation.Controllers
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