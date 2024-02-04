using System;
using System.Collections.Generic;
using Sources.Implementation.Controllers.SpaceShipStates;
using Sources.Interfaces.Services.Spaceship;
using Sources.Interfaces.SpaceshipStates;

namespace Sources.Implementation.Services.Spaceships
{
	public class SpaceshipService : ISpaceshipService
	{
		private Dictionary<Type, ISpaceshipState> _spaceshipStates;

		private ISpaceshipState _currentState;
		
		public SpaceshipService(BattleState battleState, FreeLookState freeLookState)
		{
			_spaceshipStates = new()
			{
				[battleState.GetType()] = battleState,
				[freeLookState.GetType()] = freeLookState,
			};
		}

		public void ChangeState<TState>() where TState : ISpaceshipState
		{
			Type stateType = typeof(TState);
			
			if (_spaceshipStates.TryGetValue(stateType, out ISpaceshipState spaceshipState) == false)
				throw new InvalidOperationException(nameof(stateType));

			if (_currentState == spaceshipState)
				return;

			_currentState?.Exit();
			_currentState = spaceshipState;
			_currentState.Enter();
		}
	}
}