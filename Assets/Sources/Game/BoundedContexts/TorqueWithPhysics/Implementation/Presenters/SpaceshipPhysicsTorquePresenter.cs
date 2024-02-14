using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sources.BoundedContexts.Common.Implememntation;
using Sources.Implementation.Domain;
using Sources.Implementation.Infrastructure.StateMachines.Decorators;
using Sources.Interfaces.Infrastructure.Handlers;
using Sources.Interfaces.Infrastructure.StateMachine;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.SpaceshipStates;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters
{
	/// <summary>
	/// Это типо state machine
	/// </summary>
	public class SpaceshipPhysicsTorquePresenter : PresenterBase
	{
		private readonly INotifyPropertyChanged _notifier;
		private readonly Dictionary<Type, ITorqueState> _torqueStates;
		private readonly IStateMachine<ITorqueState> _stateMachine;
		private readonly IUpdateService _updateService;
		private readonly IUpdateHandler _updateHandler;

		public SpaceshipPhysicsTorquePresenter(INotifyPropertyChanged notifier,
			Dictionary<Type, ITorqueState> torqueStates,
			IStateMachine<ITorqueState> stateMachine,
			IUpdateService updateService)
		{
			_notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
			_torqueStates = torqueStates ?? throw new ArgumentNullException(nameof(torqueStates));
			_stateMachine = stateMachine ?? throw new ArgumentNullException(nameof(stateMachine));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_updateHandler = new UpdatableStateMachine<ITorqueState>(stateMachine);
		}

		public override void Enable()
		{
			_updateService.Updated += _updateHandler.Update;
			_notifier.PropertyChanged += NotifierPropertyChanged;
		}

		public override void Disable()
		{
			_updateService.Updated -= _updateHandler.Update;
			_notifier.PropertyChanged -= NotifierPropertyChanged;
		}

		private void NotifierPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender is not Spaceship spaceship)
				return;

			if (e.PropertyName == nameof(Spaceship.CurrentState))
				OnSpaceshipStateChange(spaceship.CurrentState);
		}

		private void OnSpaceshipStateChange(ISpaceshipState spaceshipState)
		{
			if (_torqueStates.TryGetValue(spaceshipState.GetType(), out ITorqueState torqueState) == false)
				return;

			_stateMachine.Change(torqueState);
		}
	}
}