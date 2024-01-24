using Sources.Game.Implementation.Domain;
using UnityEngine;

namespace Sources.Game.Implementation.Services.Spaceships
{
	public class SpaceshipMovementService
	{
		public float GetSpeed(float direction, float acceleration, float deltaTime) =>
			direction * acceleration * deltaTime;

		public void AddForce(Spaceship spaceship, float force, float deltaTime)
		{
			if (Mathf.Abs(force) < 0.01f)
				spaceship.Speed = Mathf.MoveTowards(spaceship.Speed, 0, deltaTime * spaceship.Acceleration);
			else
				spaceship.Speed += force * deltaTime * spaceship.Acceleration;
		}

		public void AddTorque(Spaceship spaceship, float moveDirectionX, float deltaTime)
		{
			
		}
	}
}