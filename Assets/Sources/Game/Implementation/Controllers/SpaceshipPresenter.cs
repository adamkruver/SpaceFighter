using System;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Services.Spaceships;
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
        private readonly IUpdateService _updateService;
        private readonly IInputService _inputService;
        private readonly SpaceshipMovementService _movementService;

        public SpaceshipPresenter(
            Spaceship spaceship,
            ISpaceshipView spaceshipView,
            IUpdateService updateService,
            IInputService inputService,
            SpaceshipMovementService movementService
        )
        {
            _spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));
            _spaceshipView = spaceshipView ?? throw new ArgumentNullException(nameof(spaceshipView));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
        }

        public void Enable() =>
            _updateService.Updated += OnUpdate;

        private void OnUpdate(float deltaTime)
        {
            UserInput input = _inputService.UserInput;
            _spaceship.AddSpeedForce(input.MoveDirection.y * deltaTime);

            _spaceship.Position = _movementService.Move(
                _spaceship.Position,
                _spaceship.Direction,
                _spaceship.Speed,
                deltaTime
            );

            _spaceshipView.SetPosition(_spaceship.Position);
            _spaceshipView.SetDirection(_spaceship.Direction);
        }

        public void Disable() =>
            _updateService.Updated -= OnUpdate;
    }
}