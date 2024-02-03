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
                spaceship.Movement.SetSpeed(
                    Mathf.MoveTowards(spaceship.Movement.Speed, spaceship.Movement.MinSpeed, deltaTime * spaceship.Movement.Deceleration));
            else if (force > 0.01f)
                spaceship.Movement.SetSpeed(
                    Mathf.MoveTowards(spaceship.Movement.Speed, spaceship.Movement.MaxSpeed, deltaTime * spaceship.Movement.Acceleration));
        }

        public void AddTorque(Spaceship spaceship, UserInput userInput)
        {
            float mouseX = userInput.CursorPosition.x * spaceship.MouseSensitivity;
            float mouseY = userInput.CursorPosition.y * spaceship.MouseSensitivity;

            _currentRotation.x += mouseX;
            _currentRotation.y -= mouseY;

            spaceship.Torque.Destination = new Vector3(_currentRotation.y, _currentRotation.x, 0);
        }
    }
}