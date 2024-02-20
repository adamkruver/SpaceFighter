namespace Sources.Common.Observables.Interfaces.Rigidbodies
{
    public interface IObservableRigidbody : IReadOnlyObservableRigidbody
    {
        float MaxSpeed { get; set; }
        float MinSpeed { get; set; }
        float Speed { get; set; }
    }
}