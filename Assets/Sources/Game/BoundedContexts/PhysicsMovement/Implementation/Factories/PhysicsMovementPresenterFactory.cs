using System;
using Sources.BoundedContexts.PhysicsMovement.Implementation.Presenters;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Views;
using Sources.Interfaces.Services.Lifecycles;

namespace Sources.BoundedContexts.PhysicsMovement.Implementation.Factories
{
	public class PhysicsMovementPresenterFactory
	{
		private readonly ILateUpdateService _lateUpdateService;
		private readonly IFixedUpdateService _fixedUpdateService;

		public PhysicsMovementPresenterFactory(ILateUpdateService lateUpdateService, IFixedUpdateService fixedUpdateService)
		{
			_lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
			_fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
		}

		public PhysicsMovementPresenter Create(IPhysicsMovement movement, IPhysicsMovementView view) =>
			new PhysicsMovementPresenter(movement, view, _lateUpdateService, _fixedUpdateService);
	}
}