using Sources.Game.Interfaces.SpaceshipStates;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers.SpaceShipStates
{
	public class BattleState : ISpaceshipState
	{

		public BattleState()
		{
		}
		
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