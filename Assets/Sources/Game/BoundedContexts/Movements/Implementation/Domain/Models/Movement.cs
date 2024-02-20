using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.Common.Mvp.Implementation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Movements.Implementation.Domain.Models
{
	public class Movement : ObservableModel,IMovement
	{
		private float _speed;
		
		public Movement(float acceleration, float deceleration, float maxSpeed, float minSpeed)
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