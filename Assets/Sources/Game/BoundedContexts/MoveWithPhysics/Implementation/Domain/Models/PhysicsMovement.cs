using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.Common.Mvp.Implememntation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain.Models
{
	public class PhysicsMovement : ObservableModel,IPhysicsMovement
	{
		private float _speed;
		
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
		
		public float Speed
		{
			get=> _speed;
			 set=> TrySetField(ref _speed,Mathf.Clamp(value, MinSpeed, MaxSpeed));
		}
	}
}