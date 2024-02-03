using System;
using Sources.Game.Interfaces.Domain;
using UnityEngine;

namespace Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Domain
{
	public interface IPhysicsMovement
	{
		event Action VelocityChanged;

		public float Acceleration { get; }

		public float Deceleration { get; }

		public float MaxSpeed { get; }

		public float MinSpeed { get; }

		Vector3 Position { get; set; }

		Vector3 Forward { get; set; }

		Vector3 Upward { get; set; }

		float Speed { get; }

		Vector3 Velocity { get; }

		void SetSpeed(float speed);
	}
}