using Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Presenters;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Views;
using Sources.Game.Interfaces.Presentation.Views;

namespace Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Factories
{
    public interface IPhysicsMovementViewFactory<T>
        where T : IPhysicsMovementView, IPresentableView<PhysicsMovementPresenter>
    {
        IPhysicsMovementView Create(IPhysicsMovement movement, T view);
    }
}