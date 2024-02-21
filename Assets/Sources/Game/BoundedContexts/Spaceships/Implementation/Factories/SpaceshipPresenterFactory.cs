﻿using System;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Spaceships.Implementation.Presenters;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Spaceships.Implementation.Factories
{
    public class SpaceshipPresenterFactory
    {
        private readonly ILateUpdateService _lateUpdateService;

        public SpaceshipPresenterFactory(ILateUpdateService lateUpdateService) =>
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));

        public SpaceshipPresenter Create(Spaceship model, ISpaceshipView view) =>
            new SpaceshipPresenter(model, view, _lateUpdateService);
    }
}