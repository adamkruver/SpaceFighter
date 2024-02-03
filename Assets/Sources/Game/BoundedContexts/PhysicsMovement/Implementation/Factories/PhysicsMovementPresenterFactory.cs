using System;
using Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Presenters;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Views;
using Sources.Game.Interfaces.Services.Lifecycles;

namespace Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Factories
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