using System;
using System.Threading;
using Sources.BoundedContexts.Inputs.Implementation.Models;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using UnityEngine;

namespace Sources.BoundedContexts.Spaceships.Implementation.Domain.Services
{
    public class SpaceshipMovementService
    {
        private const int MouseSensitivity = 2;
        private const float MinForce = 0.01f;
        
        private Vector2 _currentRotation = Vector2.zero;

        public void AddForce(IPhysicsMovement physicsMovement, InputData inputData, float deltaTime)
        {
            float force = inputData.MoveDirection.y;

            if (force < -MinForce)
                physicsMovement.SetSpeed(
                    Mathf.MoveTowards(physicsMovement.Speed, physicsMovement.MinSpeed, deltaTime * physicsMovement.Deceleration));
            else if (force > MinForce)
                physicsMovement.SetSpeed(
                    Mathf.MoveTowards(physicsMovement.Speed, physicsMovement.MaxSpeed, deltaTime * physicsMovement.Acceleration));
        }

        public void AddForce(IPhysicsMovement physicsMovement, float force, float deltaTime)
        {
            if (force < -MinForce)
                physicsMovement.SetSpeed(
                    Mathf.MoveTowards(physicsMovement.Speed, physicsMovement.MinSpeed, deltaTime * physicsMovement.Deceleration));
            else if (force > MinForce)
                physicsMovement.SetSpeed(
                    Mathf.MoveTowards(physicsMovement.Speed, physicsMovement.MaxSpeed, deltaTime * physicsMovement.Acceleration));
        }

        public void AddTorque(IPhysicsTorque physicsTorque, InputData inputData)
        {
            float mouseX = inputData.CursorPosition.x * MouseSensitivity;
            float mouseY = inputData.CursorPosition.y * MouseSensitivity;

            _currentRotation.x += mouseY;
            _currentRotation.y -= mouseX;

            physicsTorque.Destination = _currentRotation;
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