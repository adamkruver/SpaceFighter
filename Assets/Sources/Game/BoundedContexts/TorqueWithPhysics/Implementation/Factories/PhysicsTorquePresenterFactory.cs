using System;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Interfaces.Services.Lifecycles;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Factories
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