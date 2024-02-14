using System.Threading.Tasks;
using Sources.BoundedContexts.Players.Domain;
using Sources.BoundedContexts.Players.Presentation;
using Sources.Implementation.Domain;
using Sources.Implementation.Infrastructure.Factories.Presentation.Views;
using Sources.Implementation.Presentation.Views;

namespace Sources.BoundedContexts.Players.Factories
{
	public class PlayerViewFactory
	{
		public PlayerView Create(Player player, SpaceshipViewFactory spaceshipViewFactory)
		{
			Spaceship spaceship = new Spaceship();
			SpaceshipView spaceshipView =  spaceshipViewFactory.Create(spaceship);

			return null;
		}
	}
}