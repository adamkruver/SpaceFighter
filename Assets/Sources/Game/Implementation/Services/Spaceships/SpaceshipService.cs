using System;
using System.Collections.Generic;
using Sources.Game.Implementation.Controllers;
using Sources.Game.Implementation.Controllers.SpaceShipStates;
using Sources.Game.Interfaces.SpaceshipStates;

namespace Sources.Game.Implementation.Services.Spaceships
{
	public class SpaceshipService : ISpaceshipService
	{
		private Dictionary<Type, ISpaceshipState> _spaceshipStates;

		private ISpaceshipState _currentState;
		
		public SpaceshipService()
		{
			_spaceshipStates = new()
			{
				[typeof(BattleState)] = new BattleState(),
				[typeof(FreeLookState)] = new FreeLookState(),
			};
		}

		public void ChangeSpaceshipState<TState>() where TState : ISpaceshipState
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