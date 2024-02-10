using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.Implementation.Domain;
using UnityEngine;

namespace Sources.Implementation.Services.Spaceships
{
    public class SpaceshipMovementService
    {
        private const int MouseSensitivity = 2;
        private Vector2 _currentRotation = Vector2.zero;

        public void AddForce(IPhysicsMovement physicsMovement, InputData inputData, float deltaTime)
        {
            float force = inputData.MoveDirection.y;

            if (force < -0.01f)
                physicsMovement.SetSpeed(
                    Mathf.MoveTowards(physicsMovement.Speed, physicsMovement.MinSpeed, deltaTime * physicsMovement.Deceleration));
            else if (force > 0.01f)
                physicsMovement.SetSpeed(
                    Mathf.MoveTowards(physicsMovement.Speed, physicsMovement.MaxSpeed, deltaTime * physicsMovement.Acceleration));
        }

        public void AddForce(IPhysicsMovement physicsMovement, float force, float deltaTime)
        {
            if (force < -0.01f)
                physicsMovement.SetSpeed(
                    Mathf.MoveTowards(physicsMovement.Speed, physicsMovement.MinSpeed, deltaTime * physicsMovement.Deceleration));
            else if (force > 0.01f)
                physicsMovement.SetSpeed(
                    Mathf.MoveTowards(physicsMovement.Speed, physicsMovement.MaxSpeed, deltaTime * physicsMovement.Acceleration));
        }

        public void AddTorque(IPhysicsTorque physicsTorque, InputData inputData)
        {
            float mouseX = inputData.CursorPosition.x * MouseSensitivity;
            float mouseY = inputData.CursorPosition.y * MouseSensitivity;

            _currentRotation.x += mouseX;
            _currentRotation.y -= mouseY;

            physicsTorque.Destination = new Vector3(_currentRotation.y, _currentRotation.x, 0);
        }
        
        public void AddTorque(IPhysicsTorque physicsTorque)
        {
            // // float mouseX = inputData.CursorPosition.x * physicsTorque.MouseSensitivity;
            // // float mouseY = inputData.CursorPosition.y * physicsTorque.MouseSensitivity;
            //
            // _currentRotation.x += mouseX;
            // _currentRotation.y -= mouseY;
            //
            // physicsTorque.Destination = new Vector3(_currentRotation.y, _currentRotation.x, 0);
        }
    }
}