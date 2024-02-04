using System;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.SpaceshipStates;
using UnityEngine;

namespace Sources.Implementation.Controllers.SpaceShipStates
{
	public class BattleState : ISpaceshipState
	{
		private readonly IUpdateService _updateService;

		public BattleState(IUpdateService updateService)
		{
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			Debug.Log("BattleState " + _updateService);
		}
		
		public void Enter()
		{
			_updateService.Updated += OnUpdated;
			Debug.Log(nameof(BattleState) + " enter");
		}

		public void Exit()
		{
			_updateService.Updated -= OnUpdated;
			Debug.Log(nameof(BattleState) + " exit");
		}

		private void OnUpdated(float deltaTime)
		{
			
		}
	}
}