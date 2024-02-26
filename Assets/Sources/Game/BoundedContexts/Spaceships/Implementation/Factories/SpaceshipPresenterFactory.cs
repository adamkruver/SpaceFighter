using System;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Spaceships.Implementation.Presenters;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Spaceships.Implementation.Factories
{
    public class SpaceshipPresenterFactory
    {
        private readonly IUpdateService _updateService;
        private readonly IFixedUpdateService _fixedUpdateService;

        public SpaceshipPresenterFactory(IUpdateService updateService, IFixedUpdateService fixedUpdateService)
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
        }

        public SpaceshipPresenter Create(Spaceship model, ISpaceshipView view) =>
            new SpaceshipPresenter(model, view, _updateService, _fixedUpdateService);
    }
}