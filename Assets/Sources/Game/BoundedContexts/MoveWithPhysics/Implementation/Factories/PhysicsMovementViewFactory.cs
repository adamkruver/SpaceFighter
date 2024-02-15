using System;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.MoveWithPhysics.Implementation.Factories
{
    public class PhysicsMovementViewFactory<T> : IPhysicsMovementViewFactory<T>
        where T : IPhysicsMovementView, IPresentableView<PhysicsMovementPresenter>
    {
        private readonly PhysicsMovementPresenterFactory _presenterFactory;

        public PhysicsMovementViewFactory(PhysicsMovementPresenterFactory presenterFactory) =>
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));

        public IPhysicsMovementView Create(IPhysicsMovement movement, T view)
        {
            var presenter = _presenterFactory.Create(movement, view);
            view.Construct(presenter);

            return view;
        }
    }
}