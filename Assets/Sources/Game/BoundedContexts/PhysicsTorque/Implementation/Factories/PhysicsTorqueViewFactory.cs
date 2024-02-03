using System;
using Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Presenters;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Factories;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Views;
using Sources.Game.Interfaces.Presentation.Views;

namespace Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Factories
{
    public class PhysicsTorqueViewFactory<T> : IPhysicsTorqueViewFactory<T>
        where T : IPhysicsTorqueView, IPresentableView<PhysicsTorquePresenter>
    {
        private readonly PhysicsTorquePresenterFactory _physicsTorquePresenterFactory;

        public PhysicsTorqueViewFactory(PhysicsTorquePresenterFactory physicsTorquePresenterFactory) =>
            _physicsTorquePresenterFactory = physicsTorquePresenterFactory ??
                                             throw new ArgumentNullException(nameof(physicsTorquePresenterFactory));

        public IPhysicsTorqueView Create(IPhysicsTorque torque, T view)
        {
            PhysicsTorquePresenter presenter = _physicsTorquePresenterFactory.Create(torque, view);
            view.Construct(presenter);

            return view;
        }
    }
}