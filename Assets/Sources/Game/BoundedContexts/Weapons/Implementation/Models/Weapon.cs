using System;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Models
{
	public class Weapon : IPhysicsMovement
	{
		public event Action VelocityChanged;

		public float Acceleration { get; }

		public float Deceleration { get; }

		public float MaxSpeed { get; }

		public float MinSpeed { get; }

		public Vector3 Position { get; set; }

		public Vector3 Forward { get; set; }

		public Vector3 Upward { get; set; }

		public float Speed { get; }

		public Vector3 Velocity { get; private set; }

		public void SetSpeed(float speed)
		{
			Velocity = speed * Forward;
			VelocityChanged?.Invoke();
		}
	}
}