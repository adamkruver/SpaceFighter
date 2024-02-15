using System;
using Sources.BoundedContexts.Bullets.Implementation.Domain;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Bullets.Implementation.ObjectPools;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain.Models;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Common.Mvp.Interfaces.Views;

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

			ViewObjectPool<BulletView> viewObjectPool = new ViewObjectPool<BulletView>(new BulletViewFactory());

			WeaponPresenter presenter = _weaponPresenterFactory.Create(bullet, view, viewObjectPool);
			view.Construct(presenter);
			return view;
		}
	}
}