using System;
using Sources.BoundedContexts.PhysicsMovement.Implementation.Presenters;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Factories;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Views;
using Sources.Interfaces.Presentation.Views;

namespace Sources.BoundedContexts.PhysicsMovement.Implementation.Factories
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