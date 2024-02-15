namespace Sources.BoundedContexts.Spaceships.Implementation.Services
{
	// public class SpaceshipService : ISpaceshipService
	// {
	// 	private Dictionary<Type, ISpaceshipState> _spaceshipStates;
	//
	// 	private ISpaceshipState _currentState;
	// 	
	// 	public SpaceshipService(BattleState battleState, FreeLookState freeLookState)
	// 	{
	// 		_spaceshipStates = new()
	// 		{
	// 			[battleState.GetType()] = battleState,
	// 			[freeLookState.GetType()] = freeLookState,
	// 		};
	// 	}
	//
	// 	public void ChangeState<TState>() where TState : ISpaceshipState
	// 	{
	// 		Type stateType = typeof(TState);
	// 		
	// 		if (_spaceshipStates.TryGetValue(stateType, out ISpaceshipState spaceshipState) == false)
	// 			throw new InvalidOperationException(nameof(stateType));
	//
	// 		if (_currentState == spaceshipState)
	// 			return;
	//
	// 		_currentState?.Exit();
	// 		_currentState = spaceshipState;
	// 		_currentState.Enter();
	// 	}
	// }
}