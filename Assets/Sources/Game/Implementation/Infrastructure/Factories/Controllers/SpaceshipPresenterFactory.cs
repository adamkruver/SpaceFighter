using System;
using Sources.Game.Implementation.Controllers;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Presentation.Views;
using Sources.Game.Implementation.Services.Spaceships;
using Sources.Game.Interfaces.Controllers;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Lifecycles;

namespace Sources.Game.Implementation.Infrastructure.Factories.Controllers
{
    public class SpaceshipPresenterFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IInputService _inputService;
        private readonly SpaceshipMovementService _spaceshipMovementService;

        public SpaceshipPresenterFactory(
            IUpdateService updateService,
            IInputService inputService,
            SpaceshipMovementService spaceshipMovementService
        )
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _spaceshipMovementService = spaceshipMovementService ??
                                        throw new ArgumentNullException(nameof(spaceshipMovementService));
        }

        public SpaceshipPresenter Create(
            Spaceship spaceship,
            SpaceshipView spaceshipView,
            IPhysicsMovementSystem physicsMovementSystem
        ) =>
            new SpaceshipPresenter(
                spaceship,
                spaceshipView,
                physicsMovementSystem,
                _updateService,
                _inputService,
                _spaceshipMovementService
            );
    }
}