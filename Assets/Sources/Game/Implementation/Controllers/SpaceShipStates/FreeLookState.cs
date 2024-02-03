using Sources.Game.Interfaces.Infrastructure.States;
using Sources.Game.Interfaces.SpaceshipStates;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers.SpaceShipStates
{
	public class FreeLookState : ISpaceshipState
	{
		public void Enter()
		{
			Debug.Log(nameof(FreeLookState) + " enter");
		}

		public void Exit()
		{
			Debug.Log(nameof(FreeLookState) + " exit");
		}
	}
}