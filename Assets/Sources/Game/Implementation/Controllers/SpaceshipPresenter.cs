using System;
using System.Timers;
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
        private readonly SpaceshipMovementService _movementService;

        public SpaceshipPresenter(
            Spaceship spaceship,
            ISpaceshipView spaceshipView,
            IPhysicsMovementSystem physicsMovementSystem,
            IUpdateService updateService,
            IInputService inputService,
            SpaceshipMovementService movementService
        )
        {
            _spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));
            _spaceshipView = spaceshipView ?? throw new ArgumentNullException(nameof(spaceshipView));
            _physicsMovementSystem = physicsMovementSystem ?? throw new ArgumentNullException(nameof(physicsMovementSystem));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
        }

        public void Enable() =>
            _updateService.Updated += OnUpdate;

        public void Disable() =>
            _updateService.Updated -= OnUpdate;

        private void OnUpdate(float deltaTime)
        {
            UserInput input = _inputService.UserInput;
            
            // TODO изменил логику расчёта скорости
            //_movementService.AddForce(_spaceship, input.MoveDirection.y, deltaTime);
            //_physicsMovementSystem.AddForce(_physicsMovementSystem.Forward * speed);

            // TODO изменил на Time.fixedDeltaTime т.к. скорость изменяется от 28 до 31 единиц. А так скорость держится ровно на 30   
            float speed = _spaceship.GetSpeed(input.MoveDirection.y, Time.fixedDeltaTime);
            
            _physicsMovementSystem.SetVelocity(_physicsMovementSystem.Forward * speed);
            
            _spaceship.Position = _physicsMovementSystem.Position;
            _spaceship.Forward = _physicsMovementSystem.Forward;
            _spaceship.Upwards = _physicsMovementSystem.Upwards;
            
            // _movementService.Move(_spaceship, deltaTime);
            //
            // _spaceshipView.SetPosition(_spaceship.Position);
            // _spaceshipView.SetDirection(_spaceship.Direction);
        }
    }
}