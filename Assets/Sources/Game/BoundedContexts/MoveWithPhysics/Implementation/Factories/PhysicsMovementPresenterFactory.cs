using System;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.MoveWithPhysics.Implementation.Factories
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