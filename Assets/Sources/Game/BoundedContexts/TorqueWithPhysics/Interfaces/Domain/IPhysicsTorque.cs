using System.ComponentModel;
using UnityEngine;

namespace Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain
{
    public interface IPhysicsTorque
    {
        Quaternion Rotation { get; set; }
        Vector3 Destination { get; set; }
        float RotationSpeed { get; }
    }
}