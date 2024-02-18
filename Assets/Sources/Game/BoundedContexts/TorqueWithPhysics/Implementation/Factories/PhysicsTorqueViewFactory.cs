using System;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Factories
{
    public class PhysicsTorqueViewFactory
    {
        private readonly PhysicsTorquePresenterFactory _presenterFactory;

        public PhysicsTorqueViewFactory(PhysicsTorquePresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IPhysicsTorqueView Create(IPhysicsTorque model, PhysicsTorqueView view)
        {
            SpaceshipPhysicsTorquePresenter presenter = _presenterFactory.Create(model, view);
            view.Construct(presenter);

            return view;
        }
    }
}