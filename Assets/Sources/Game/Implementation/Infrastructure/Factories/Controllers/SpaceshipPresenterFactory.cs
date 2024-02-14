using System;
using Sources.Implementation.Controllers;
using Sources.Implementation.Domain;
using Sources.Implementation.Services.Spaceships;
using Sources.Interfaces.Presentation.Views;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.Services.Spaceship;
using Sources.Interfaces.Services.TargetFollowers;

namespace Sources.Implementation.Infrastructure.Factories.Controllers
{
    public class SpaceshipPresenterFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IInputService _inputService;
        private readonly SpaceshipMovementService _spaceshipMovementService;
        private readonly ICameraFollower _cameraFollower;
        //private readonly ISpaceshipService _spaceshipService;

        public SpaceshipPresenterFactory(
            IUpdateService updateService,
            IInputService inputService,
            SpaceshipMovementService spaceshipMovementService,
            ICameraFollower cameraFollower
            //ISpaceshipService spaceshipService
        )
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _spaceshipMovementService = spaceshipMovementService ??
                                        throw new ArgumentNullException(nameof(spaceshipMovementService));
            _cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
            //_spaceshipService = spaceshipService ?? throw new ArgumentNullException(nameof(spaceshipService));
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
                _cameraFollower
                //_spaceshipService
            );
    }
}