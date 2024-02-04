using Sources.BoundedContexts.PhysicsMovement.Implementation.Presenters;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Views;
using Sources.Interfaces.Presentation.Views;

namespace Sources.BoundedContexts.PhysicsMovement.Interfaces.Factories
{
    public interface IPhysicsMovementViewFactory<T>
        where T : IPhysicsMovementView, IPresentableView<PhysicsMovementPresenter>
    {
        IPhysicsMovementView Create(IPhysicsMovement movement, T view);
    }
}