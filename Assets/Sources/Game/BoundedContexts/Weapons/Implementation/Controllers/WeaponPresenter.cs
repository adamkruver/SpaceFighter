using System;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Bullets.Interfaces.Domain;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.BoundedContexts.Common.Implememntation;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.Services.Spaceship;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Controllers
{
	public class WeaponPresenter : PresenterBase
	{
		private readonly IBullet _bullet;
		private readonly IWeaponView _weaponView;
		private readonly IInputService _inputService;
		private readonly IUpdateService _service;
		private readonly IWeaponShootService _weaponShootService;
		private readonly IBulletViewFactory _bulletViewFactory;

		public WeaponPresenter(
			IBullet bullet,
			IWeaponView weaponView,
			IInputService inputService,
			IUpdateService service,
			IWeaponShootService weaponShootService,
			IBulletViewFactory bulletViewFactory)
		{
			_bullet = bullet ?? throw new ArgumentNullException(nameof(bullet));
			_weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_weaponShootService = weaponShootService ?? throw new ArgumentNullException(nameof(weaponShootService));
			_bulletViewFactory = bulletViewFactory ?? throw new ArgumentNullException(nameof(bulletViewFactory));
		}

		public override void Enable() =>
			_service.Updated += OnUpdated;

		public override void Disable() =>
			_service.Updated -= OnUpdated;

		private void OnUpdated(float delta)
		{
			if (_inputService.InputData.IsFire)
				Shoot(delta);
		}

		private void Shoot(float delta)
		{
			_bullet.PhysicsMovement.Position = _weaponView.GetPosition();
			_bullet.PhysicsMovement.Forward = _weaponView.GetForward();
			_bullet.PhysicsTorque.Rotation = _weaponView.GetRotation();
			
			_weaponShootService.SetSpeed(_bullet.PhysicsMovement, delta);

			IBulletView bullets = _bulletViewFactory.Create(_bullet.PhysicsMovement.Position, _bullet.PhysicsTorque.Rotation);
			bullets.SetVelocity(_bullet.PhysicsMovement.Velocity);
			Debug.Log(_bullet.PhysicsMovement.Velocity);
		}
	}
}