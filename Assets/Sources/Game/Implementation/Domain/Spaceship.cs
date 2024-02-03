using System;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.Game.Interfaces.Domain;
using UnityEngine;

namespace Sources.Game.Implementation.Domain
{
    public class Spaceship : ITarget
    {
        private const float Acceleration = 5f;
        private const float Deceleration = 2f;
        private const float MaxSpeed = 50f;
        private const float MinSpeed = 0f;

        public Spaceship(IPhysicsMovement physicsMovement, IPhysicsTorque physicsTorque)
        {
            Movement = physicsMovement ?? throw new ArgumentNullException(nameof(physicsMovement));
            Torque = physicsTorque ?? throw new ArgumentNullException(nameof(physicsTorque));
        }

        public Spaceship() : this(new PhysicsMovement(Acceleration, Deceleration, MaxSpeed, MinSpeed), new PhysicsTorque())
        {}
        
        public IPhysicsMovement Movement { get; }

        public IPhysicsTorque Torque { get; }

        public float MouseSensitivity { get; } = 2f;

        public Vector3 Upward => Movement.Upward;

        public Vector3 Forward => Movement.Forward;

        public Vector3 Position => Movement.Position;
    }
}
