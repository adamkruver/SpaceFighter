using Sources.Common.Observables.Transforms.Interfaces.Models.ReadOnly;
using UnityEngine;

namespace Sources.Common.Observables.Transforms.Interfaces.Models
{
    public interface IObservablePosition : IReadOnlyObservablePosition
    {
        Vector3 Position { get; set; }
    }
}