using System;
using Sources.BoundedContexts.Bullets.Implementation.Domain;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.ObjectPools;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Interfaces.Presentation.Views;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
	public class WeaponViewFactory : IWeaponViewFactory
	{
		private readonly WeaponPresenterFactory _weaponPresenterFactory;

		public WeaponViewFactory(WeaponPresenterFactory weaponPresenterFactory) =>
			_weaponPresenterFactory = weaponPresenterFactory ?? throw new ArgumentNullException(nameof(weaponPresenterFactory));

		public IWeaponView Create<T>(T view) where T : IPresentableView<WeaponPresenter>, IWeaponView
		{
			Bullet bullet = new Bullet(new PhysicsMovement(10f, 1f, 50f, 0f), new PhysicsTorque());
			
			BulletObjectPool bulletObjectPool = new BulletObjectPool(new BulletViewFactory());

			WeaponPresenter presenter = _weaponPresenterFactory.Create(bullet, view, bulletObjectPool);
			view.Construct(presenter);
			return view;
		}
	}
}