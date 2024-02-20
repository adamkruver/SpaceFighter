using System;
using System.ComponentModel;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.Common.Mvp.Implementation.Presenters;

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
            switch (e.PropertyName)
            {
                case nameof(Spaceship.Velocity):
                    UpdateVelocity();
                    break;
            }
        }

        private void UpdateVelocity() =>
            _spaceshipView.SetVelocity(_spaceship.Velocity);
    }
}