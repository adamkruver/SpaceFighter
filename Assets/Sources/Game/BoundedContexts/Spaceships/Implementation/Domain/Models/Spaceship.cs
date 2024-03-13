using Sources.BoundedContexts.Spaceships.Interfaces.States;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Models;
using Sources.Common.Observables.Rigidbodies.Implementation.Models;
using Sources.Interfaces.Domain;
using UnityEngine;

namespace Sources.BoundedContexts.Spaceships.Implementation.Domain.Models
{
    public class Spaceship : ObservableRigidbody, ITarget
    {
        public const float MaxAcceleration = 700f;
        public const float MinAcceleration = -200f;

        private ISpaceshipState _state;
        private Quaternion _destination;
        private float _acceleration;
        private Weapon _weapon;
        
        public Spaceship()
        {
            MaxSpeed = 700f;
            MinSpeed = 0f;
        }

        public Weapon Weapon
        {
            get => _weapon;
            set => TrySetField(ref _weapon, value);
        }

        public ISpaceshipState State
        {
            get => _state;
            set => TrySetField(ref _state, value);
        }
        
        public Quaternion Destination
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