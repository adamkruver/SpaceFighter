using System;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Services;
using Sources.BoundedContexts.Spaceships.Implementation.Presenters;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;

namespace Sources.BoundedContexts.Spaceships.Implementation.Factories
{
    public class SpaceshipPresenterFactory
    {
        private readonly SpaceshipMovementService _spaceshipMovementService;

        public SpaceshipPresenterFactory(SpaceshipMovementService spaceshipMovementService)
        {
            _spaceshipMovementService = spaceshipMovementService ?? throw new ArgumentNullException(nameof(spaceshipMovementService));
        }

        public SpaceshipPresenter Create(Spaceship spaceship, ISpaceshipView spaceshipView) =>
            new SpaceshipPresenter(spaceship, spaceshipView,_spaceshipMovementService);
    }
}