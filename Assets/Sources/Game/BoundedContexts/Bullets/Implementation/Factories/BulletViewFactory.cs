using System;
using Sources.BoundedContexts.Bullets.Implementation.Models;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
	public class BulletViewFactory
	{
		private readonly BulletPresenterFactory _presenterFactory;

		public BulletViewFactory(BulletPresenterFactory presenterFactory) =>
			_presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));

		public BulletView Create(Bullet model, BulletView view)
		{
			var presenter = _presenterFactory.Create(model, view);
			view.Construct(presenter);

			return view;
		}
	}
}