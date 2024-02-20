using Sources.BoundedContexts.Movements.Implementation.Presenters;
using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.BoundedContexts.Movements.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.Movements.Interfaces.Factories
{
    public interface IPhysicsMovementViewFactory<T>
        where T : IPhysicsMovementView, IPresentableView<PhysicsMovementPresenter>
    {
        IPhysicsMovementView Create(IMovement movement, T view);
    }
}