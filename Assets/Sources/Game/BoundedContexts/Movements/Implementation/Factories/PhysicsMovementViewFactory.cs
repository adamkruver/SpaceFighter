using System;
using Sources.BoundedContexts.Movements.Implementation.Presenters;
using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.BoundedContexts.Movements.Interfaces.Factories;
using Sources.BoundedContexts.Movements.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.Movements.Implementation.Factories
{
    public class PhysicsMovementViewFactory<T> : IPhysicsMovementViewFactory<T>
        where T : IPhysicsMovementView, IPresentableView<PhysicsMovementPresenter>
    {
        private readonly PhysicsMovementPresenterFactory _presenterFactory;

        public PhysicsMovementViewFactory(PhysicsMovementPresenterFactory presenterFactory) =>
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));

        public IPhysicsMovementView Create(IMovement movement, T view)
        {
            var presenter = _presenterFactory.Create(movement, view);
            view.Construct(presenter);

            return view;
        }
    }
}