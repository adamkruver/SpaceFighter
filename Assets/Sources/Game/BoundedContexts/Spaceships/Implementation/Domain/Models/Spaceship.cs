using Sources.BoundedContexts.Spaceships.Interfaces.States;
using Sources.Common.Observables.Implementation.Rigidbodies;
using Sources.Interfaces.Domain;
using UnityEngine;

namespace Sources.BoundedContexts.Spaceships.Implementation.Domain.Models
{
    public class Spaceship : ObservableRigidbody, ITarget
    {
        private const float AccelerationModifier = 5f;
        private const float DecelerationModifier = 2f;

        private ISpaceshipState _state;
        private Vector3 _destination;
        private float _acceleration;

        public Spaceship()
        {
            MaxSpeed = 50f;
            MinSpeed = 0f;
        }

        public ISpaceshipState State
        {
            get => _state;
            set => TrySetField(ref _state, value);
        }
        
        public Vector3 Destination
        {
            get => _destination;
            set => TrySetField(ref _destination, value);
        }
        
        public float Acceleration
        {
            get => _acceleration;
            set => TrySetField(ref _acceleration, value);
        }
    }
}