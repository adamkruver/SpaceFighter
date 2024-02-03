using UnityEngine;

namespace Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Domain
{
    public interface IPhysicsTorque
    {
        Quaternion Rotation { get; set; }
        Vector3 Torque { get; set; }
        float RotationSpeed { get; set; }
    }
}