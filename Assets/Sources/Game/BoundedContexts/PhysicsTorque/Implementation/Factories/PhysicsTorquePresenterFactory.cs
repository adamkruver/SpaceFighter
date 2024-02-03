using System;
using Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Presenters;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Services;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Views;
using Sources.Game.Interfaces.Services.Lifecycles;

namespace Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Factories
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

        public PhysicsTorquePresenter Create(IPhysicsTorque torque, IPhysicsTorqueView view) =>
            new PhysicsTorquePresenter(torque, view, _updateService, _torqueService);
    }
}