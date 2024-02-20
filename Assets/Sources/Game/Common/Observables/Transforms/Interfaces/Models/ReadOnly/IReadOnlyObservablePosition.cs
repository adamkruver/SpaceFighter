using System.ComponentModel;
using UnityEngine;

namespace Sources.Common.Observables.Transforms.Interfaces.Models.ReadOnly
{
    public interface IReadOnlyObservablePosition : INotifyPropertyChanged
    {
        Vector3 Position { get; }
    }
}