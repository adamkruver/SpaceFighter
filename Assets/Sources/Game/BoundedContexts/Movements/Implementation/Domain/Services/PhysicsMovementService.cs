using Sources.Common.Observables.Interfaces.Rigidbodies;
using UnityEngine;

namespace Sources.BoundedContexts.Movements.Implementation.Domain.Services
{
    public class PhysicsMovementService
    {
        private const float MinForce = 0.01f;

        public void AddForce(IObservableRigidbody rigidbody, float force, float acceleration, float deltaTime)
        {
            switch (force)
            {
                case < -MinForce:
                    MoveTowards(rigidbody, rigidbody.MinSpeed, acceleration, deltaTime);
                    break;

                case > MinForce:
                    MoveTowards(rigidbody, rigidbody.MaxSpeed, acceleration, deltaTime);
                    break;
            }
        }

        private void MoveTowards(
            IObservableRigidbody movement,
            float destination,
            float acceleration,
            float deltaTime
        ) =>
            movement.Speed =
                Mathf.MoveTowards(
                    movement.Speed,
                    destination,
                    deltaTime * acceleration
                );
    }
}