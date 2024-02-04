using Sources.Interfaces.SpaceshipStates;
using UnityEngine;

namespace Sources.Implementation.Controllers.SpaceShipStates
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