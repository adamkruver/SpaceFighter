using System;
using Sources.Game.Interfaces.Services.Lifecycles;
using Sources.Game.Interfaces.SpaceshipStates;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers.SpaceShipStates
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