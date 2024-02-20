using UnityEngine;

namespace Sources.Common.Observables.Interfaces.Positions
{
    public interface IObservablePosition : IReadOnlyObservablePosition
    {
        Vector3 Position { get; set; }
    }
}