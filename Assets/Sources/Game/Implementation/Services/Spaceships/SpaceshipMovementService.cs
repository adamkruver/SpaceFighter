using Sources.Game.Implementation.Domain;
using Sources.Game.Interfaces.Services.Inputs;
using UnityEngine;

namespace Sources.Game.Implementation.Services.Spaceships
{
	public class SpaceshipMovementService
	{
		private Vector2 _currentRotation = Vector2.zero;

		public void AddForce(Spaceship spaceship, UserInput input, float deltaTime)
		{
			float force = input.MoveDirection.y;

			if (force < -0.01f)
				spaceship.Speed = Mathf.MoveTowards(spaceship.Speed, Spaceship.MinSpeed, deltaTime * spaceship.Deceleration);
			else if(force > 0.01f)
				spaceship.Speed = Mathf.MoveTowards(spaceship.Speed, Spaceship.MaxSpeed, deltaTime * spaceship.Acceleration);
		}

		public Vector3 AddTorque(Spaceship spaceship, UserInput userInput)
		{
			float mouseX = userInput.CursorPosition.x * spaceship.MouseSensetivity;
			float mouseY = userInput.CursorPosition.y * spaceship.MouseSensetivity;

			_currentRotation.x += mouseX;
			_currentRotation.y -= mouseY;

			return new Vector3(_currentRotation.y, _currentRotation.x, 0);
		}
	}
}