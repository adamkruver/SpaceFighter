using Sources.Common.Observables.Transforms.Interfaces.Models.ReadOnly;
using UnityEngine;

namespace Sources.Common.Observables.Transforms.Interfaces.Models
{
    public interface IObservableRotation : IReadOnlyObservableRotation
    {
        Quaternion Rotation { get; set; }
    }
}