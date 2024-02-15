using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using UnityEngine;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Services
{
    public class PhysicsTorqueService
    {
        public void AddTorque(IPhysicsTorque physicsTorque, float rotationX, float rotationY) => 
            physicsTorque.Destination += new Vector3(-rotationY, rotationX, 0);
    }
}