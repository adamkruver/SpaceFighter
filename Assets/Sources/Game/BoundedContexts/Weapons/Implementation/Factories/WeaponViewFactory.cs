using System;
using Sources.BoundedContexts.Assets.Implementation;
using Sources.BoundedContexts.Bullets.Implementation.Domain;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Bullets.Implementation.ObjectPools;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain.Models;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Implementation.Domain;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
	public class WeaponViewFactory : IWeaponViewFactory
	{
		private readonly WeaponPresenterFactory _weaponPresenterFactory;
		private readonly BulletAssetProvider _bulletAssetProvider;
		private BulletViewFactory _bulletViewFactory;

		public WeaponViewFactory(WeaponPresenterFactory weaponPresenterFactory, BulletAssetProvider bulletAssetProvider)
		{
			_weaponPresenterFactory = weaponPresenterFactory ?? throw new ArgumentNullException(nameof(weaponPresenterFactory));
			_bulletAssetProvider = bulletAssetProvider ?? throw new ArgumentNullException(nameof(bulletAssetProvider));
		}

		public IWeaponView Create<T>(T view) where T : IPresentableView<WeaponPresenter>, IWeaponView
		{
			Weapon weapon = new Weapon();
			Bullet bullet = new Bullet(new PhysicsMovement(10f, 1f, 50f, 0f), new PhysicsTorque());

			BulletViewFactory bulletViewFactory = null;
			ViewObjectPool<BulletView> viewObjectPool = new ViewObjectPool<BulletView>(CreateBulletView);
			_bulletViewFactory = new BulletViewFactory(_bulletAssetProvider, viewObjectPool);

			WeaponPresenter presenter = _weaponPresenterFactory.Create(bullet, view, viewObjectPool);
			//WeaponPresenter presenter = _weaponPresenterFactory.Create(weapon, view, viewObjectPool);
			view.Construct(presenter);
			return view;
		}

		private BulletView CreateBulletView() =>
			_bulletViewFactory.Create();
	}
}