using System;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.Game.Interfaces.Domain;
using UnityEngine;

namespace Sources.Game.Implementation.Domain
{
    public class Spaceship : ITarget, IPhysicsMovement, IPhysicsTorque
    {
        public const float MaxSpeed = 50f;
        public const float MinSpeed = 0f;

        public event Action VelocityChanged;
        
        public float Acceleration { get; set; } = 10f;
        public float Deceleration { get; set; } = 25f;
        public Vector3 Position { get; set; }
        public Vector3 Forward { get; set; }
        public Vector3 Upward { get; set; }
        public Vector3 Velocity { get; private set; }

        public Vector3 Upwards { get; set; }

        public float TorqueForce { get; set; }

        public float MouseSensitivity { get; } = 2f;
        public float Speed { get; private set; }

        public Quaternion Rotation { get; set; }

        public Vector3 Torque { get; set; }

        public float RotationSpeed { get; set; } = 2f;

        public void SetSpeed(float speed)
        {
            Speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);
            Velocity = Speed * Forward;
            
            VelocityChanged?.Invoke();
        }
    }
}