using System;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using UnityEngine;

namespace Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain.Models
{
	public class PhysicsMovement : IPhysicsMovement
	{
		public PhysicsMovement(float acceleration, float deceleration, float maxSpeed, float minSpeed)
		{
			Acceleration = acceleration;
			Deceleration = deceleration;
			MaxSpeed = maxSpeed;
			MinSpeed = minSpeed;
		}
		
		public float Acceleration { get; }

		public float Deceleration { get; }

		public float MaxSpeed { get; }

		public float MinSpeed { get; }

		public Vector3 Position { get; set; }

		public Vector3 Forward { get; set; }

		public Vector3 Upward { get; set; }

		public event Action VelocityChanged;
		
		public float Speed { get; private set; }

		public Vector3 Velocity { get; private set; }
		
		public void SetSpeed(float speed)
		{
			Speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);
			Velocity = Speed * Forward;

			VelocityChanged?.Invoke();
		}
	}
}