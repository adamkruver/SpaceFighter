using System;
using Sources.BoundedContexts.Inputs.Implementation.Models;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.Movements.Implementation.Domain.Services;
using Sources.BoundedContexts.Players.Implementation.Models;
using Sources.Common;
using Sources.Common.Observables.Rigidbodies.Implementation.Domain.Services;
using Sources.Common.StateMachines.Implementation.Contexts.States;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.Players.Implementation.Presenters.States
{
	public class SpaceshipControlState : ContextStateBase, IUpdateHandler
	{
		private const int MouseSensitivity = 50; // TODO: Move to config

		private readonly Player _player;
		private readonly IInputService _inputService;
		private readonly MovementService _movementService;
		private readonly RigidbodyMovementService _rigidbodyMovementService;
		private readonly IFixedUpdateService _fixedUpdateService;

		public SpaceshipControlState(Player player,
			IInputService inputService,
			MovementService movementService,
			RigidbodyMovementService rigidbodyMovementService,
			IFixedUpdateService fixedUpdateService)
		{
			_player = player ?? throw new ArgumentNullException(nameof(player));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
			_rigidbodyMovementService = rigidbodyMovementService ?? throw new ArgumentNullException(nameof(rigidbodyMovementService));
			_fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
			_fixedUpdateService.FixedUpdated += FixedUpdate;
		}

		private void FixedUpdate(float deltaTime)
		{
			HandleInput(_inputService.InputData);
			UpdateModels(deltaTime);
		}

		public void Update(float deltaTime)
		{
			// Fire(_inputService.InputData);
		}

		private void Fire(InputData inputService)
		{
			if (inputService.IsFire)
				_player.Spaceship.Weapon.Shoot();
		}

		private void HandleInput(InputData inputData)
		{
			var cursorPosition = inputData.CursorPosition;
			float destinationX = cursorPosition.x * MouseSensitivity;
			float destinationY = cursorPosition.y * MouseSensitivity;
		
			// _movementService.AddTorque(_player.Spaceship, destinationX, destinationY);
			
			_movementService.AddForce(_player.Spaceship,
				_inputService.InputData.MoveDirection.y);
		}

		private void UpdateModels(float deltaTime)
		{
			// _rigidbodyMovementService.Rotate(
			// 	_player.Spaceship,
			// 	_player.Spaceship.Destination, 
			// 	deltaTime * Config.SpaceshipRotationSpeed);

			_rigidbodyMovementService.CalculateSpeed(_player.Spaceship,
				_player.Spaceship.Acceleration,
				deltaTime);
		}
	}
}