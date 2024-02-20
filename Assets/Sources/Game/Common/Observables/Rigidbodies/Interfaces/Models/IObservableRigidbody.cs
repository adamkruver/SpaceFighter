using Sources.Common.Observables.Transforms.Interfaces.Models;

namespace Sources.Common.Observables.Interfaces.Rigidbodies
{
    public interface IObservableRigidbody : IReadOnlyObservableRigidbody, IObservableTransform
    {
        float MaxSpeed { get; set; }
        float MinSpeed { get; set; }
        float Speed { get; set; }
    }
}