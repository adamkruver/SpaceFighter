using System;
using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Implementation.Models;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
	public class BulletPresenterFactory
	{
		private readonly IUpdateService _updateService;

		public BulletPresenterFactory(IUpdateService updateService) =>
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));

		
		public BulletPresenter Create(Bullet model, IBulletView view) =>
			new BulletPresenter(model, view, _updateService);	}
}