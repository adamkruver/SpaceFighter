using System.ComponentModel;
using UnityEngine;

namespace Sources.Common.Observables.Interfaces.Rotations
{
    public interface IReadOnlyObservableRotation : INotifyPropertyChanged
    {
        Vector3 Forward { get; }
        Vector3 Upward { get; }
        Vector3 Right { get; }
        Quaternion Rotation { get; }
    }
}