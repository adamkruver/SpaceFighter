using System;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;

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

        public SpaceshipPhysicsTorquePresenter Create(IPhysicsTorque model, IPhysicsTorqueView view) =>
            new SpaceshipPhysicsTorquePresenter(model, view, _updateService, _torqueService);
    }
}