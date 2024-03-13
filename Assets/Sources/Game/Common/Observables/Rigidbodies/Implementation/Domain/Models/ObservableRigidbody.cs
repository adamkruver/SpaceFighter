using Sources.Common.Observables.Interfaces.Rigidbodies;
using Sources.Common.Observables.Transforms.Implementation.Models;
using UnityEngine;

namespace Sources.Common.Observables.Rigidbodies.Implementation.Models
{
	public class ObservableRigidbody : ObservableTransform, IObservableRigidbody
	{
		private float _speed;
		private Vector3 _velocity;
		private float _minSpeed = 0f;
		private float _maxSpeed = float.MaxValue;

		public Vector3 Position { get; set; }
		public float MaxSpeed
		{
			get => _maxSpeed;

			set
			{
				_maxSpeed = value;
				Speed = Speed;
			}
		}

		public float MinSpeed
		{
			get => _minSpeed;

			set
			{
				_minSpeed = value;
				Speed = Speed;
			}
		}

		public float Speed
		{
			get => _speed;

			set
			{
				if (TrySetField(ref _speed, Mathf.Clamp(value, MinSpeed, MaxSpeed)) == false)
					return;

				CalculateVelocity(_speed);
			}
		}

		public Vector3 Velocity
		{
			get => _velocity;

			private set => TrySetField(ref _velocity, value);
		}

		private void CalculateVelocity(float speed) =>
			Velocity = Forward * (speed * Time.fixedDeltaTime);
	}
}