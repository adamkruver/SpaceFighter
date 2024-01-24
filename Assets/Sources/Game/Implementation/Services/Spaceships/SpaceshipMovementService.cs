using Sources.Game.Implementation.Domain;
using UnityEngine;

namespace Sources.Game.Implementation.Services.Spaceships
{
    public class SpaceshipMovementService
    {
        public void AddForce(Spaceship spaceship, UserInput input, float deltaTime)
        {
            float force = input.MoveDirection.y;

            if (Mathf.Abs(force) < 0.01f)
                spaceship.Speed = Mathf.MoveTowards(spaceship.Speed, 0, deltaTime * spaceship.Acceleration);
            else
                spaceship.Speed += force * deltaTime * spaceship.Acceleration;

            float cursorPositionX = Mathf.Clamp(input.CursorPosition.x, 0, Screen.width);

            spaceship.TorqueForce = 2 * cursorPositionX / Screen.width - 1; // Clamped from -1 to 1
            spaceship.TorqueForce *= spaceship.Speed / Spaceship.MaxSpeed;
        }
    }
}