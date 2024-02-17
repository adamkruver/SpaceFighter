using System;
using Sources.BoundedContexts.Inputs.Implementation.Models;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain.Services;
using Sources.BoundedContexts.Players.Implementation.Models;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Services;
using Sources.Common.StateMachines.Implementation.Contexts.States;
using Sources.Common.StateMachines.Interfaces.Handlers;

namespace Sources.BoundedContexts.Players.Implementation.Presenters.States
{
    public class SpaceshipControlState : ContextStateBase, IUpdateHandler
    {
        private const int MouseSensitivity = 2; // TODO: Move to config

        private readonly Player _player;
        private readonly IInputService _inputService;
        private readonly PhysicsMovementService _movementService;
        private readonly PhysicsTorqueService _torqueService;

        public SpaceshipControlState(
            Player player,
            IInputService inputService,
            PhysicsMovementService movementService,
            PhysicsTorqueService torqueService
        )
        {
            _player = player ?? throw new ArgumentNullException(nameof(player));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
            _torqueService = torqueService;
        }

        public void Update(float deltaTime)
        {
            Move(_inputService.InputData, deltaTime);
            Torque(_inputService.InputData);
        }

        private void Move(InputData inputData, float deltaTime) =>
            _movementService.AddForce(_player.Spaceship.Movement, inputData.MoveDirection.y, deltaTime);

        private void Torque(InputData inputData)
        {
            var cursorPosition = inputData.CursorPosition;
            float destinationX = cursorPosition.x * MouseSensitivity;
            float destinationY = cursorPosition.y * MouseSensitivity;

            _torqueService.AddTorque(_player.Spaceship.Torque, destinationX, destinationY);
        }
    }
}