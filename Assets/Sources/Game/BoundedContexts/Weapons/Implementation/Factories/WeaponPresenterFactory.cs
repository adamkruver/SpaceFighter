using System;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Bullets.Implementation.ObjectPools;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.Bullets.Interfaces.Domain;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Implementation.Domain;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Common.Mvp.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Spaceship;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
	public class WeaponPresenterFactory
	{
		private readonly IInputService _inputService;
		private readonly IUpdateService _updateService;
		private readonly IWeaponShootService _weaponShootService;

		public WeaponPresenterFactory(IInputService inputService, IUpdateService updateService, IWeaponShootService weaponShootService)
		{
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_weaponShootService = weaponShootService ?? throw new ArgumentNullException(nameof(weaponShootService));
		}

		public WeaponPresenter Create(IBullet bullet, IWeaponView weaponView, ViewObjectPool<BulletView> viewObjectPool) =>
			new WeaponPresenter(bullet,
				weaponView,
				viewObjectPool,
				_inputService,
				_updateService,
				_weaponShootService);

		public WeaponPresenter Create<T>(Weapon weapon,
			T weaponView,
			ViewObjectPool<BulletView> viewObjectPool)
			where T : IPresentableView<WeaponPresenter>, IWeaponView =>
			new WeaponPresenter(weapon,
				weaponView,
				viewObjectPool,
				_inputService,
				_updateService,
				_weaponShootService);
	}
}