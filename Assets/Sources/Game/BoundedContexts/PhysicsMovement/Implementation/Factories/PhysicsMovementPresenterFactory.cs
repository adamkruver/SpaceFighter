using System;
using Sources.BoundedContexts.PhysicsMovement.Implementation.Presenters;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Views;
using Sources.Interfaces.Services.Lifecycles;

namespace Sources.BoundedContexts.PhysicsMovement.Implementation.Factories
{
    public class PhysicsMovementPresenterFactory
    {
        private readonly IFixedUpdateService _fixedUpdateService;

        public PhysicsMovementPresenterFactory(IFixedUpdateService fixedUpdateService) => 
            _fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));

        public PhysicsMovementPresenter Create(IPhysicsMovement movement, IPhysicsMovementView view) =>
            new PhysicsMovementPresenter(movement, view, _fixedUpdateService);
    }
}