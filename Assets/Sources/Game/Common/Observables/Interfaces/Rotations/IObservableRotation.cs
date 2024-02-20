using UnityEngine;

namespace Sources.Common.Observables.Interfaces.Rotations
{
    public interface IObservableRotation : IReadOnlyObservableRotation
    {
        Quaternion Rotation { get; set; }
    }
}