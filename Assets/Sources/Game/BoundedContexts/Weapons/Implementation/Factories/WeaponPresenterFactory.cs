using System;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Bullets.Interfaces.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.Services.Spaceship;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
	public class WeaponPresenterFactory
	{
		private readonly IInputService _inputService;
		private readonly IUpdateService _updateService;
		private readonly IWeaponShootService _weaponShootService;

		public WeaponPresenterFactory(IInputService inputService,  IUpdateService updateService, IWeaponShootService weaponShootService)
		{
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_weaponShootService = weaponShootService ?? throw new ArgumentNullException(nameof(weaponShootService));
		}
		
		public WeaponPresenter Create(IBullet bullet, IWeaponView weaponView, IBulletViewFactory bulletViewFactory) =>
			new WeaponPresenter(
				bullet,
				weaponView,
				_inputService,
				_updateService, 
				_weaponShootService,
				bulletViewFactory);
	}	
}
