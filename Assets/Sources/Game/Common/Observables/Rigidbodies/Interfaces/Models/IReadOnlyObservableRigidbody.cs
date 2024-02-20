using System.ComponentModel;
using UnityEngine;

namespace Sources.Common.Observables.Interfaces.Rigidbodies
{
    public interface IReadOnlyObservableRigidbody : INotifyPropertyChanged
    {
        float MaxSpeed { get; }
        float MinSpeed { get; }
        float Speed { get; }
        Vector3 Velocity { get; }
    }
}