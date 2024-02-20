using Sources.Common.Observables.Interfaces.Positions;
using Sources.Common.Observables.Interfaces.Rotations;

namespace Sources.Common.Observables.Interfaces.Transforms
{
    public interface IObservableTransform : IObservablePosition, IObservableRotation
    {
    }
}