using System;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Models.Decorators;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Common.Mvp.Interfaces.Views;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Factories
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