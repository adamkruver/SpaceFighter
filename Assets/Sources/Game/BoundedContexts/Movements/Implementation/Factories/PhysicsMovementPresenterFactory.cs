using System;
using Sources.BoundedContexts.Movements.Implementation.Presenters;
using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.BoundedContexts.Movements.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Movements.Implementation.Factories
{
	public class PhysicsMovementPresenterFactory
	{
		private readonly IUpdateService _lateUpdateService;


		public PhysicsMovementPresenterFactory(IUpdateService lateUpdateService) => 
			_lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));

		public PhysicsMovementPresenter Create(IMovement movement, IPhysicsMovementView view) =>
			new PhysicsMovementPresenter(movement, view, _lateUpdateService);
	}
}