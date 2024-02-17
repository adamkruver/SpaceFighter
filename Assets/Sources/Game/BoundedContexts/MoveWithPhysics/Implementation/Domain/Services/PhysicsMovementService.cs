using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using UnityEngine;

namespace Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain.Services
{
    public class PhysicsMovementService
    {
        private const float MinForce = 0.01f;

        public void AddForce(IPhysicsMovement physicsMovement, float force, float deltaTime)
        {
            switch (force)
            {
                case < -MinForce:
                    MoveTowards(physicsMovement, physicsMovement.MinSpeed, deltaTime);
                    break;
                
                case > MinForce:
                    MoveTowards(physicsMovement, physicsMovement.MaxSpeed, deltaTime);
                    break;
            }
        }

        private void MoveTowards(IPhysicsMovement physicsMovement, float destination, float deltaTime) =>
            physicsMovement.Speed =
                Mathf.MoveTowards(
                    physicsMovement.Speed,
                    destination,
                    deltaTime * physicsMovement.Acceleration
                )
            ;
    }
}