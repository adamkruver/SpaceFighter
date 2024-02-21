using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Movements.Implementation.Domain.Services
{
	public class MovementService
	{
		// TODO MinForce вынести в конфиг
		private const float MinForce = 0.01f;

		public void AddTorque(Spaceship spaceship, float rotationX, float rotationY) =>
			spaceship.Destination = spaceship.Rotation * Quaternion.Euler(-rotationY, rotationX, 0);
		
		public void AddForce(Spaceship spaceship, float force)
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
					deltaTime);
	}
}