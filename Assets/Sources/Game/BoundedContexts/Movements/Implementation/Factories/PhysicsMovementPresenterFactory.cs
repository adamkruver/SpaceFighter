using System;
using Sources.BoundedContexts.Movements.Implementation.Presenters;
using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.BoundedContexts.Movements.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Movements.Implementation.Factories
{
	public class PhysicsMovementPresenterFactory
	{
		private readonly IUpdateService _updateService;


		public PhysicsMovementPresenterFactory(IUpdateService updateService) => 
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));

		public PhysicsMovementPresenter Create(IMovement movement, IPhysicsMovementView view) =>
			new PhysicsMovementPresenter(movement, view, _updateService);
	}
}