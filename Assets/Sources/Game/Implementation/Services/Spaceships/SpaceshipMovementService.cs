using Sources.Game.Implementation.Domain;
using UnityEngine;

namespace Sources.Game.Implementation.Services.Spaceships
{
    public class SpaceshipMovementService
    {
        public void Move(Spaceship spaceship, float deltaTime)
        {
     //       spaceship.Position += spaceship.Speed * deltaTime * spaceship.Direction;
        }

        public void AddForce(Spaceship spaceship, float force, float deltaTime)
        {
            // TODO зачем тут условие?
            // if (Mathf.Abs(force) < 0.01f)
            //     spaceship.Speed = Mathf.MoveTowards(spaceship.Speed, 0, deltaTime * spaceship.Acceleration);
            // else
                spaceship.Speed += force * deltaTime * spaceship.Acceleration;
        }
    }
}