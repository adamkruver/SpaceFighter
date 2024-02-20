using System.ComponentModel;
using UnityEngine;

namespace Sources.Common.Observables.Transforms.Interfaces.Models.ReadOnly
{
    public interface IReadOnlyObservableRotation : INotifyPropertyChanged
    {
        Vector3 Forward { get; }
        Vector3 Upward { get; }
        Vector3 Right { get; }
        Quaternion Rotation { get; }
    }
}