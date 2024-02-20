using System.ComponentModel;
using Sources.Common.Observables.Transforms.Interfaces.Models.ReadOnly;
using UnityEngine;

namespace Sources.Common.Observables.Interfaces.Rigidbodies
{
    public interface IReadOnlyObservableRigidbody : IReadOnlyObservableTransform
    {
        float MaxSpeed { get; }
        float MinSpeed { get; }
        float Speed { get; }
        Vector3 Velocity { get; }
    }
}