using System;
using Sources.Game.Implementation.Controllers;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Presentation.Views;
using Sources.Game.Implementation.Services.Spaceships;
using Sources.Game.Interfaces.Presentation.Views;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Lifecycles;
using Sources.Game.Interfaces.Services.Spaceship;
using Sources.Game.Interfaces.Services.TargetFollowers;

namespace Sources.Game.Implementation.Infrastructure.Factories.Controllers
{
    public class SpaceshipPresenterFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IInputService _inputService;
        private readonly SpaceshipMovementService _spaceshipMovementService;
        private readonly ICameraFollower _cameraFollower;
        private readonly ISpaceshipService _spaceshipService;

        public SpaceshipPresenterFactory(
            IUpdateService updateService,
            IInputService inputService,
            SpaceshipMovementService spaceshipMovementService,
            ICameraFollower cameraFollower,
            ISpaceshipService spaceshipService
        )
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _spaceshipMovementService = spaceshipMovementService ??
                                        throw new ArgumentNullException(nameof(spaceshipMovementService));
            _cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
            _spaceshipService = spaceshipService ?? throw new ArgumentNullException(nameof(spaceshipService));
        }

        public SpaceshipPresenter Create(
            Spaceship spaceship,
            ISpaceshipView spaceshipView
        ) =>
            new SpaceshipPresenter(
                spaceship,
                spaceshipView,
                _updateService,
                _inputService,
                _spaceshipMovementService,
                _cameraFollower,
                _spaceshipService
            );
    }
}