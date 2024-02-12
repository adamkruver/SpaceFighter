using System;
using Sources.Interfaces.Domain;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.SpaceshipStates;
using UnityEngine;

namespace Sources.Implementation.Controllers.SpaceShipStates
{
	public class BattleState : ISpaceshipState
	{
		
		public void Enter()
		{
			Debug.Log(nameof(BattleState) + " enter");
		}

		public void Exit()
		{
			Debug.Log(nameof(BattleState) + " exit");
		}
	}
}