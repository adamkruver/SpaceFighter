using System.ComponentModel;
using UnityEngine;

namespace Sources.Common.Observables.Interfaces.Positions
{
    public interface IReadOnlyObservablePosition : INotifyPropertyChanged
    {
        Vector3 Position { get; }
    }
}