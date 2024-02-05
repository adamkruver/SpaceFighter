using System;
using Sources.BoundedContexts.Common.Implememntation;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.BoundedContexts.Weapons.Implementation.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Projectiles;
using Sources.BoundedContexts.Weapons.Interfaces.Weapons;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Controllers
{
	public class WeaponPresenter : PresenterBase
	{
		private readonly IPhysicsMovement _physicsMovement;
		private readonly IPhysicsTorque _physicsTorque;
		private readonly IInputService _inputService;
		private readonly IUpdateService _service;
		private ProjectilesFactory _projectilesFactory;

		public WeaponPresenter(IPhysicsMovement physicsMovement,
			IPhysicsTorque physicsTorque,
			IInputService inputService,
			IUpdateService service)
		{
			_physicsMovement = physicsMovement ?? throw new ArgumentNullException(nameof(physicsMovement));
			_physicsTorque = physicsTorque ?? throw new ArgumentNullException(nameof(physicsTorque));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_service = service ?? throw new ArgumentNullException(nameof(service));
			_projectilesFactory = new ProjectilesFactory();
		}

		public override void Enable()
		{
			_service.Updated += OnUpdated;
		}

		public override void Disable()
		{
			_service.Updated -= OnUpdated;
		}

		private void OnUpdated(float delta)
		{
			if (_inputService.UserInput.IsFire)
				Fire(delta);
		}

		public void SetPosition(Vector3 position) =>
			_physicsMovement.Position = position;

		public void SetRotation(Quaternion rotation) =>
			_physicsTorque.Destination = rotation.eulerAngles;

		private void Fire(float delta)
		{
			Mathf.MoveTowards(_physicsMovement.Speed, _physicsMovement.MinSpeed, delta * _physicsMovement.Deceleration);			
			IProjectile projectiles = _projectilesFactory.Create(_physicsMovement.Position, Quaternion.Euler(_physicsTorque.Destination));
			projectiles.SetVelocity(_physicsMovement.Velocity);
		}
	}
}