using Sources.Game.Implementation.Domain;
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
                spaceship.SetSpeed(
                    Mathf.MoveTowards(spaceship.Speed, Spaceship.MinSpeed, deltaTime * spaceship.Deceleration)
                );
            else if (force > 0.01f)
                spaceship.SetSpeed(
                    Mathf.MoveTowards(spaceship.Speed, Spaceship.MaxSpeed, deltaTime * spaceship.Acceleration)
                );
        }

        public void AddTorque(Spaceship spaceship, UserInput userInput)
        {
            float mouseX = userInput.CursorPosition.x * spaceship.MouseSensitivity;
            float mouseY = userInput.CursorPosition.y * spaceship.MouseSensitivity;

            _currentRotation.x += mouseX;
            _currentRotation.y -= mouseY;

            spaceship.Torque = new Vector3(_currentRotation.y, _currentRotation.x, 0);
        }
    }
}