using Sources.Game.Interfaces.Domain;
using Sources.Game.Interfaces.Services.TargetFollowers;
using UnityEngine;

namespace Sources.Game.Implementation.Domain
{
	public class Spaceship : ITarget
	{
		public const float MaxSpeed = 50f;
		
		public const float MinSpeed = 0f;

		private float _speed;

		public Vector3 Position { get; set; }

		public float Acceleration { get; set; } = 10f;

		public float Deceleration { get; set; } = 25f;

		public Vector3 Forward { get; set; }

		public Vector3 Upwards { get; set; }

		public float Speed
		{
			get => _speed;

			set => _speed = Mathf.Clamp(value, MinSpeed, MaxSpeed);
		}
		
		public float TorqueForce { get; set; }

		public float MouseSensetivity => 2f;
	}
}