using UnityEngine;

namespace Sources.Game.Implementation.Services.Spaceships
{
    public class SpaceshipMovementService
    {
        public Vector3 Move(Vector3 currentPosition, Vector3 direction, float speed, float deltaTime) => 
            currentPosition + speed * deltaTime * direction;
    }
}