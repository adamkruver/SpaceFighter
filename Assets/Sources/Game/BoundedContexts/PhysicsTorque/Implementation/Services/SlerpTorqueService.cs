using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Services;
using UnityEngine;

namespace Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Services
{
    public class SlerpTorqueService : ITorqueService
    {
        public void UpdateTorque(IPhysicsTorque torque, float deltaTime) =>
            torque.Rotation = Quaternion.Slerp(
                torque.Rotation,
                Quaternion.Euler(torque.Torque),
                torque.RotationSpeed * deltaTime
            );
    }
}