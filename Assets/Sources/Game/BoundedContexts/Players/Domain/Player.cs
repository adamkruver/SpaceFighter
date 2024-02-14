using System;
using Sources.Implementation.Domain;
using Sources.Implementation.Infrastructure.Factories.Presentation.Views;

namespace Sources.BoundedContexts.Players.Domain
{
	public class Player : ObservableModel
	{
		private Spaceship _spaceship;

		public Player()
		{
			_spaceship = new Spaceship();
		}

		public Spaceship Spaceship => _spaceship;
	}
}