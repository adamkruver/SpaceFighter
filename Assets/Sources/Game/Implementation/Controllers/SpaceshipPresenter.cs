using System;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Services.Spaceships;
using Sources.Game.Interfaces.Controllers;
using Sources.Game.Interfaces.Presentation.Views;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Lifecycles;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers
{
    public class SpaceshipPresenter
    {
        private readonly Spaceship _spaceship;
        private readonly ISpaceshipView _spaceshipView;
        private readonly IPhysicsMovementSystem _physicsMovementSystem;
        private readonly IUpdateService _updateService;
        private readonly IInputService _inputService;
        private readonly IFixedUpdateService _fixedUpdateService;
        private readonly SpaceshipMovementService _movementService;

        public SpaceshipPresenter(
            Spaceship spaceship,
            ISpaceshipView spaceshipView,
            IPhysicsMovementSystem physicsMovementSystem,
            IUpdateService updateService,
            IFixedUpdateService fixedUpdateService,
            IInputService inputService,
            SpaceshipMovementService movementService
        )
        {
            _spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));
            _spaceshipView = spaceshipView ?? throw new ArgumentNullException(nameof(spaceshipView));
            _physicsMovementSystem =
                physicsMovementSystem ?? throw new ArgumentNullException(nameof(physicsMovementSystem));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
            _movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
        }

        public void Enable()
        {
            _updateService.Updated += OnUpdate;
            _fixedUpdateService.FixedUpdated += _physicsMovementSystem.UpdateFixed;
        }

        public void Disable()
        {
            _updateService.Updated -= OnUpdate;
            _fixedUpdateService.FixedUpdated -= _physicsMovementSystem.UpdateFixed;
        }

        private void OnUpdate(float deltaTime)
        {
            UserInput input = _inputService.UserInput;

            _movementService.AddForce(_spaceship, input, deltaTime);

            _physicsMovementSystem.SetSpeed(_spaceship.Speed);
            _physicsMovementSystem.SetTorqueForce(_spaceship.TorqueForce);

            _spaceship.Position = _physicsMovementSystem.Position;
            _spaceship.Forward = _physicsMovementSystem.Forward;
            _spaceship.Upwards = _physicsMovementSystem.Up;
        }
    }
}