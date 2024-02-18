using System;
using Sources.BoundedContexts.Bullets.Implementation.Services;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
	public class WeaponPresenterFactory
	{
		private readonly BulletService _bulletService;

		public WeaponPresenterFactory( BulletService bulletService)
		{
			_bulletService = bulletService ?? throw new ArgumentNullException(nameof(bulletService));
		}

		public WeaponPresenter Create( IWeaponView view )
		{
			Weapon weapon = new Weapon();
			
			var presenter = new WeaponPresenter(weapon, view, _bulletService);

			return presenter;
		}

		// public WeaponPresenter Create<T>(Weapon weapon,
		// 	T weaponView,
		// 	ViewObjectPool<BulletView> viewObjectPool)
		// 	where T : IPresentableView<WeaponPresenter>, IWeaponView =>
		// 	new WeaponPresenter(weapon,
		// 		weaponView,
		// 		viewObjectPool,
		// 		_inputService,
		// 		_updateService,
		// 		_weaponShootService);
	}
}