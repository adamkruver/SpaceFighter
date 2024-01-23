using UnityEngine;

namespace Sources.Game.Implementation.Domain
{
	public class Spaceship
	{
		private const int MinSpeed = -100;
		private const int MaxSpeed = 100;

		private float _speed;

		public Vector3 Position { get; set; }

		public float Speed
		{
			get => _speed;

			set => _speed = Mathf.Clamp(value, MinSpeed, MaxSpeed); // TODO: Remove magic number
		}

		public float Acceleration { get; set; } = 1000f;

		public Vector3 Forward { get; set; }

		public Vector3 Upwards { get; set; }

		public float GetSpeed(float direction, float deltaTime) =>
			Speed = direction * Acceleration * deltaTime;
	}
}