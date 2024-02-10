using Sources.BoundedContexts.MoveWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Views;
using Sources.Interfaces.Presentation.Views;

namespace Sources.BoundedContexts.MoveWithPhysics.Interfaces.Factories
{
    public interface IPhysicsMovementViewFactory<T>
        where T : IPhysicsMovementView, IPresentableView<PhysicsMovementPresenter>
    {
        IPhysicsMovementView Create(IPhysicsMovement movement, T view);
    }
}