﻿using System;
using System.ComponentModel;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.Common.Mvp.Implememntation.Presenters;
using Sources.Interfaces.SpaceshipStates;

namespace Sources.BoundedContexts.Spaceships.Implementation.Presenters
{
    public class SpaceshipPresenter : PresenterBase
    {
        private readonly Spaceship _spaceship;
        private readonly ISpaceshipView _spaceshipView;

        public SpaceshipPresenter(
            Spaceship spaceship,
            ISpaceshipView spaceshipView
        )
        {
            _spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));
            _spaceshipView = spaceshipView ?? throw new ArgumentNullException(nameof(spaceshipView));
        }

        public override void Enable() => 
            _spaceship.PropertyChanged += OnModelPropertyChanged;

        public override void Disable() => 
            _spaceship.PropertyChanged -= OnModelPropertyChanged;

        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is not Spaceship spaceship)
                return;

            if (e.PropertyName == nameof(Spaceship.State))
                OnModelStateChanged(spaceship.State);
        }

        private void OnModelStateChanged(ISpaceshipState spaceshipState)
        {
        }
    }
}