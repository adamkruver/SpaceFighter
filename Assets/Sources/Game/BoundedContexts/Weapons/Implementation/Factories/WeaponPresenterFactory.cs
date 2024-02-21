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
		private readonly ILateUpdateService _lateUpdateService;

		public WeaponPresenterFactory(BulletService bulletService, ILateUpdateService lateUpdateService)
		{
			_bulletService = bulletService ?? throw new ArgumentNullException(nameof(bulletService));
			_lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
		}

		public WeaponPresenter Create(Weapon weapon, IWeaponView view, SpaceshipService service) =>
			new WeaponPresenter(weapon, view, _lateUpdateService, _bulletService, service);
	}
}