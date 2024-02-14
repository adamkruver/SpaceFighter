using System;
using System.Collections.Generic;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Views;
using Sources.Implementation.Controllers.SpaceShipStates;
using Sources.Implementation.Infrastructure.StateMachines;
using Sources.Interfaces.Services.Lifecycles;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Factories
{
	public class PhysicsTorquePresenterFactory
	{
		private readonly IUpdateService _updateService;
		private readonly ITorqueService _torqueService;

		public PhysicsTorquePresenterFactory(IUpdateService updateService,
			ITorqueService torqueService)
		{
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_torqueService = torqueService ?? throw new ArgumentNullException(nameof(torqueService));
		}

		public SpaceshipPhysicsTorquePresenter Create(ObservablePhysicsTorque observablePhysicsTorque, IPhysicsTorqueView view)
		{
			Dictionary<Type, ITorqueState> states = new Dictionary<Type, ITorqueState>()
			{
				[typeof(TorqueState)] = new TorqueState(observablePhysicsTorque, view, _torqueService),
				[typeof(BlockTorqueState)] = new BlockTorqueState(observablePhysicsTorque, view, _torqueService)
			};

			StateMachine<ITorqueState> stateMachine = new StateMachine<ITorqueState>();

			return new SpaceshipPhysicsTorquePresenter(observablePhysicsTorque, states, stateMachine, _updateService);
		}
	}
}