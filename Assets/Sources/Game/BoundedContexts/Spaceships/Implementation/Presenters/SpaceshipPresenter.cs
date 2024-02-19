using System;
using System.ComponentModel;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Services;
using Sources.BoundedContexts.Spaceships.Interfaces.States;
using Sources.BoundedContexts.Spaceships.Interfaces.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.Common.Mvp.Implememntation.Presenters;

namespace Sources.BoundedContexts.Spaceships.Implementation.Presenters
{
    public class SpaceshipPresenter : PresenterBase
    {
        private readonly Spaceship _spaceship;
        private readonly ISpaceshipView _spaceshipView;
        private readonly SpaceshipMovementService _spaceshipMovementService;

        public SpaceshipPresenter(
            Spaceship spaceship,
            ISpaceshipView spaceshipView,
            SpaceshipMovementService spaceshipMovementService
        )
        {
            _spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));
            _spaceshipView = spaceshipView ?? throw new ArgumentNullException(nameof(spaceshipView));
            _spaceshipMovementService = spaceshipMovementService ??
                                        throw new ArgumentNullException(nameof(spaceshipMovementService));
        }

        public override void Enable()
        {
            _spaceship.PropertyChanged += OnModelPropertyChanged;
            _spaceship.Torque.PropertyChanged += OnTorquePropertyChanged;
            _spaceship.Movement.PropertyChanged += OnMovementPropertyChanged;
        }


        public override void Disable()
        {
            _spaceship.PropertyChanged -= OnModelPropertyChanged;
            _spaceship.Torque.PropertyChanged -= OnTorquePropertyChanged;
            _spaceship.Movement.PropertyChanged -= OnMovementPropertyChanged;
        }

        private void OnMovementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is not IPhysicsMovement movement)
                return;

            if (e.PropertyName == nameof(IPhysicsMovement.Speed))
                CalculateVelocity();
        }
        
        private void OnTorquePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is not IPhysicsTorque torque)
                return;

            if (e.PropertyName == nameof(IPhysicsTorque.Rotation))
                CalculateVelocity();
        }

        private void CalculateVelocity() =>
            _spaceshipMovementService.CalculateVelocity(_spaceship);

        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender is not Spaceship spaceship)
                return;

            if (e.PropertyName == nameof(Spaceship.State))
                OnModelStateChanged(spaceship.State);

            if (e.PropertyName == nameof(Spaceship.Velocity))
                _spaceshipView.SetVelocity(spaceship.Velocity);
        }

        private void OnModelStateChanged(ISpaceshipState spaceshipState)
        {
        }
    }
}