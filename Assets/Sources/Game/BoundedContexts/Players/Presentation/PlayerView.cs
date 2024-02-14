using System;
using Sources.BoundedContexts.Players.Domain;
using Sources.Implementation.Infrastructure.Factories.Presentation.Views;
using Sources.Implementation.Presentation.Views;
using UniCtor.Attributes;

namespace Sources.BoundedContexts.Players.Presentation
{
	public class PlayerView : View
	{
		public SpaceshipViewFactory SpaceshipViewFactory { get; private set; }

		[Constructor]
		private void Construct(SpaceshipViewFactory spaceshipViewFactory) =>
			SpaceshipViewFactory = spaceshipViewFactory ?? throw new ArgumentNullException(nameof(spaceshipViewFactory));
	}
}