using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.Common.Observables.Interfaces.Rigidbodies;
using UnityEngine;

namespace Sources.BoundedContexts.Movements.Implementation.Domain.Services
{
	public class PhysicsMovementService
	{
		private const float MinForce = 0.01f;

		public void CalculateSpeed(IObservableRigidbody rigidbody, float acceleration, float deltaTime) =>
			rigidbody.Speed = Mathf.MoveTowards(rigidbody.Speed, rigidbody.Speed + acceleration, deltaTime);

		public void AddForce(Spaceship spaceship, float force, float deltaTime)
		{
			switch (force)
			{
				case < -MinForce:
					spaceship.Acceleration = Spaceship.MinAcceleration;
					//MoveTowards(spaceship, Spaceship.MinAcceleration, deltaTime);
					break;

				case > MinForce:
					spaceship.Acceleration = Spaceship.MaxAcceleration;
					//MoveTowards(spaceship, Spaceship.MaxAcceleration, deltaTime);
					break;
			}
		}

		private void MoveTowards(Spaceship spaceship,
			float target,
			float deltaTime) =>
			spaceship.Acceleration =
				Mathf.MoveTowards(spaceship.Acceleration,
					target,
					deltaTime );
	}
}