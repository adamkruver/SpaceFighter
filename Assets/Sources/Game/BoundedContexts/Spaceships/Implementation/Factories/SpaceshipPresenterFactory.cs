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

        public SpaceshipPresenterFactory(IUpdateService updateService) =>
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));

        public SpaceshipPresenter Create(Spaceship model, ISpaceshipView view) =>
            new SpaceshipPresenter(model, view, _updateService);
    }
}