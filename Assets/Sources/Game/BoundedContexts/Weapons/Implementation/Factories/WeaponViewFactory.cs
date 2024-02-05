using System;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.BoundedContexts.Weapons.Implementation.Controllers;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
	public class WeaponViewFactory : IWeaponViewFactory
	{
		private readonly WeaponPresenterFactory _weaponPresenterFactory;

		public WeaponViewFactory(WeaponPresenterFactory weaponPresenterFactory) =>
			_weaponPresenterFactory = weaponPresenterFactory ?? throw new ArgumentNullException(nameof(weaponPresenterFactory));

		public IWeaponView Create(IPhysicsMovement physicsMovement, IPhysicsTorque spaceshipTorque, IWeaponView weaponView)
		{
			var presenter = _weaponPresenterFactory.Create(physicsMovement, spaceshipTorque);
			weaponView.Construct(presenter);
			return weaponView;
		}
	}

	public class WeaponPresenterFactory
	{
		private readonly IInputService _inputService;
		private readonly IUpdateService _updateService;

		public WeaponPresenterFactory( IInputService inputService, IUpdateService updateService)
		{
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
		}
		
		public WeaponPresenter Create(IPhysicsMovement physicsMovement, IPhysicsTorque spaceshipTorque) =>
			new WeaponPresenter(physicsMovement,
				spaceshipTorque,
				_inputService,
				_updateService);
	}

	public interface IWeaponViewFactory
	{
		IWeaponView  Create(IPhysicsMovement spaceshipMovement, IPhysicsTorque spaceshipTorque, IWeaponView weaponView);
	}
}