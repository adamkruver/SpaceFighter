using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Torques.Implementation.Domain.Services
{
    public class PhysicsTorqueService
    {
        public void AddTorque(Spaceship physicsTorque, float rotationX, float rotationY) => 
            physicsTorque.Destination += new Vector3(-rotationY, rotationX, 0);
    }
}