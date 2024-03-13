using System;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.Movements.Implementation.Domain.Services;
using Sources.BoundedContexts.Players.Implementation.Models;
using Sources.Common.Observables.Rigidbodies.Implementation.Domain.Services;
using Sources.Common.StateMachines.Implementation.Contexts.States;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Players.Implementation.Presenters.States
{
	public class SpaceshipControlState : ContextStateBase, IUpdateHandler
	{
		private readonly Player _player;
		private readonly IInputService _inputService;
		private readonly MovementService _movementService;
		private readonly RigidbodyMovementService _rigidbodyMovementService;
		private readonly IFixedUpdateService _fixedUpdateService;
		private readonly IUpdateService _updateService;

		public SpaceshipControlState(Player player,
			IInputService inputService,
			MovementService movementService,
			RigidbodyMovementService rigidbodyMovementService,
			IFixedUpdateService fixedUpdateService,
			IUpdateService updateService)
		{
			_player = player ?? throw new ArgumentNullException(nameof(player));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
			_rigidbodyMovementService = rigidbodyMovementService ?? throw new ArgumentNullException(nameof(rigidbodyMovementService));
			_fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			
			_fixedUpdateService.FixedUpdated += FixedUpdate;
			_updateService.Updated += OnUpdate;
		}

		private void OnUpdate(float deltaTime)
		{
		}

		private void FixedUpdate(float deltaTime)
		{
			HandleInput();
			UpdateModels(deltaTime);
		}

		public void Update(float deltaTime) =>
			Fire();

		private void Fire()
		{
			if (_inputService.InputData.IsFire)
				_player.Spaceship.Weapon.Shoot();
		}

		// TODO перименовать
		private void HandleInput() =>
			_movementService.AddForce(_player.Spaceship,
				_inputService.InputData.MoveDirection.y);

		private void UpdateModels(float deltaTime) =>
			_rigidbodyMovementService.CalculateSpeed(_player.Spaceship,
				_player.Spaceship.Acceleration,
				deltaTime);
	}
}