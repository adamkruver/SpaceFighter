using System;
using Sources.BoundedContexts.Torques.Implementation.Presenters;
using Sources.BoundedContexts.Torques.Interfaces.Domain;
using Sources.BoundedContexts.Torques.Interfaces.Services;
using Sources.BoundedContexts.Torques.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Torques.Implementation.Factories
{
    public class PhysicsTorquePresenterFactory
    {
        private readonly IUpdateService _updateService;
        private readonly ITorqueService _torqueService;

        public PhysicsTorquePresenterFactory(
            IUpdateService updateService,
            ITorqueService torqueService
        )
        {
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _torqueService = torqueService ?? throw new ArgumentNullException(nameof(torqueService));
        }

        public SpaceshipPhysicsTorquePresenter Create(IPhysicsTorque model, IPhysicsTorqueView view) =>
            new SpaceshipPhysicsTorquePresenter(model, view, _updateService, _torqueService);
    }
}