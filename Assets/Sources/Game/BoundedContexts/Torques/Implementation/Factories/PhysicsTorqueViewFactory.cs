using System;
using Sources.BoundedContexts.Torques.Implementation.Presenters;
using Sources.BoundedContexts.Torques.Implementation.Views;
using Sources.BoundedContexts.Torques.Interfaces.Domain;
using Sources.BoundedContexts.Torques.Interfaces.Views;

namespace Sources.BoundedContexts.Torques.Implementation.Factories
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