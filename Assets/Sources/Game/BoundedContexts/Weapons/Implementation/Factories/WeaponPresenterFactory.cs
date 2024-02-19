using System;
using Sources.BoundedContexts.Bullets.Implementation.Services;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Interfaces.Domain.Models;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
	public class WeaponPresenterFactory
	{
		private readonly BulletService _bulletService;

		public WeaponPresenterFactory(BulletService bulletService)
		{
			_bulletService = bulletService ?? throw new ArgumentNullException(nameof(bulletService));
		}

		public WeaponPresenter Create(IWeapon model, IWeaponView view)
		{
			var presenter = new WeaponPresenter(model, view, _bulletService);

			return presenter;
		}
	}
}