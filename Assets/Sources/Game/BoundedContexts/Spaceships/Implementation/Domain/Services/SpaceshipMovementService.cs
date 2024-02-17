using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Spaceships.Implementation.Domain.Services
{
    public class SpaceshipMovementService
    {
        public void CalculateVelocity(Spaceship spaceship) =>
            spaceship.Velocity = spaceship.Torque.Rotation * Vector3.forward * spaceship.Movement.Speed;
    }
}