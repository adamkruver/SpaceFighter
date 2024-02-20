using System;
using Sources.BoundedContexts.Bullets.Implementation.Services;
using Sources.BoundedContexts.Spaceships.Implementation.Services;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Implementation.Presenters;
using Sources.BoundedContexts.Weapons.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
	public class WeaponPresenterFactory
	{
		private readonly BulletService _bulletService;
		private readonly IUpdateService _updateService;

		public WeaponPresenterFactory(BulletService bulletService, IUpdateService updateService)
		{
			_bulletService = bulletService ?? throw new ArgumentNullException(nameof(bulletService));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
		}

		public WeaponPresenter Create(Weapon weapon, IWeaponView view, SpaceshipService service) =>
			new WeaponPresenter(weapon, view, _updateService, _bulletService, service);
	}
}