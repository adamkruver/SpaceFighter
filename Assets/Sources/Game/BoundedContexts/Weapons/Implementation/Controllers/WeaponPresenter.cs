using System;
using Sources.BoundedContexts.Bullets.Implementation.ObjectPools;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.Bullets.Interfaces.Domain;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.Weapons.Implementation.Domain;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.BoundedContexts.Weapons.Interfaces.Services;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Common.Mvp.Implememntation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Controllers
{
	public class WeaponPresenter : PresenterBase
	{
		private readonly IBullet _bullet;
		private readonly Weapon _weapon;
		private readonly IWeaponView _weaponView;
		private readonly ViewObjectPool<BulletView> _viewObjectPool;
		private readonly IInputService _inputService;
		private readonly IUpdateService _service;
		private readonly IWeaponShootService _weaponShootService;

		public WeaponPresenter(
			IBullet bullet,
			IWeaponView weaponView,
			ViewObjectPool<BulletView> viewObjectPool,
			IInputService inputService,
			IUpdateService service,
			IWeaponShootService weaponShootService)
		{
			_bullet = bullet ?? throw new ArgumentNullException(nameof(bullet));
			_weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
			_viewObjectPool = viewObjectPool ?? throw new ArgumentNullException(nameof(viewObjectPool));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_weaponShootService = weaponShootService ?? throw new ArgumentNullException(nameof(weaponShootService));
		}

		// public WeaponPresenter(
		// 	Weapon weapon,
		// 	IWeaponView weaponView,
		// 	ViewObjectPool<BulletView> viewObjectPool,
		// 	IInputService inputService,
		// 	IUpdateService service,
		// 	IWeaponShootService weaponShootService)
		// {
		// 	_weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
		// 	_weaponView = weaponView ?? throw new ArgumentNullException(nameof(weaponView));
		// 	_viewObjectPool = viewObjectPool ?? throw new ArgumentNullException(nameof(viewObjectPool));
		// 	_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
		// 	_service = service ?? throw new ArgumentNullException(nameof(service));
		// 	_weaponShootService = weaponShootService ?? throw new ArgumentNullException(nameof(weaponShootService));
		// }
		//
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

			IBulletView bulletView = CreateBullet();

			bulletView.SetVelocity(_bullet.PhysicsMovement.Velocity);
		}

		private IBulletView CreateBullet()
		{
			BulletView bulletView = _viewObjectPool.ObjectPool.Get() as BulletView; // TODO проверка на as BulletView 

			bulletView.SetPosition(_weaponView.GetPosition());
			bulletView.SetRotation(_weaponView.GetRotation());
			bulletView.SetForward(_weaponView.GetForward());
			return bulletView;
		}
	}
}