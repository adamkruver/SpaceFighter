using System.ComponentModel;
using UnityEngine;

namespace Sources.BoundedContexts.Torques.Interfaces.Domain
{
    public interface IPhysicsTorque : INotifyPropertyChanged
    {
        float RotationSpeed { get; }
        Quaternion Rotation { get; set; }
        Vector3 Destination { get; set; }
    }
}