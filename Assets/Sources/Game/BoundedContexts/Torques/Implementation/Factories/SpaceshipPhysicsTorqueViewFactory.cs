using System;
using Sources.BoundedContexts.Torques.Implementation.Presenters;
using Sources.BoundedContexts.Torques.Interfaces.Domain;
using Sources.BoundedContexts.Torques.Interfaces.Factories;
using Sources.BoundedContexts.Torques.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.Torques.Implementation.Factories
{
    public class SpaceshipPhysicsTorqueViewFactory<T> : IPhysicsTorqueViewFactory<T>
        where T : IPhysicsTorqueView, IPresentableView<SpaceshipPhysicsTorquePresenter>
    {
        private readonly PhysicsTorquePresenterFactory _physicsTorquePresenterFactory;

        public SpaceshipPhysicsTorqueViewFactory(PhysicsTorquePresenterFactory physicsTorquePresenterFactory) =>
            _physicsTorquePresenterFactory = physicsTorquePresenterFactory ??
                                             throw new ArgumentNullException(nameof(physicsTorquePresenterFactory));

        public IPhysicsTorqueView Create(IPhysicsTorque torque, T view)
        {
            SpaceshipPhysicsTorquePresenter presenter = _physicsTorquePresenterFactory.Create(torque, view);
            view.Construct(presenter);

            return view;
        }
    }
}