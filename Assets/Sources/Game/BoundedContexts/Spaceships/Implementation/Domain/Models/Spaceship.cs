using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain.Models;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.Spaceships.Interfaces.States;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Models;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.Common.Mvp.Implememntation.Models;
using Sources.Interfaces.Domain;
using UnityEngine;

namespace Sources.BoundedContexts.Spaceships.Implementation.Domain.Models
{
    public class Spaceship : ObservableModel, ITarget
    {
        private const float Acceleration = 5f;
        private const float Deceleration = 2f;
        private const float MaxSpeed = 50f;
        private const float MinSpeed = 0f;

        private ISpaceshipState _state;
        private Vector3 _velocity;

        public Spaceship()
        {
            Torque = new PhysicsTorque();
            Movement = new PhysicsMovement(Acceleration, Deceleration, MaxSpeed, MinSpeed);
        }
        
        public IPhysicsMovement Movement { get; }

        public IPhysicsTorque Torque { get; }

        public Vector3 Upward => Movement.Upward;

        public Vector3 Forward => Movement.Forward;

        public Vector3 Position => Movement.Position;

        public Vector3 Velocity
        {
            get => _velocity;
            set => TrySetField(ref _velocity, value);
        }

        public ISpaceshipState State
        {
            get => _state;

            set => TrySetField(ref _state, value);
        }
    }
}