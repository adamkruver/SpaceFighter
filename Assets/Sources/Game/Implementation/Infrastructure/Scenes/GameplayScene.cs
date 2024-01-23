using Sources.Game.Interfaces.Infrastructure.Scenes;
using UnityEngine;

namespace Sources.Game.Implementation.Infrastructure.Scenes
{
	public class GameplayScene : IScene
	{
		public void Enter()
		{
			Debug.Log("Enter GameplayScene");
		}

		public void Exit()
		{
			Debug.Log("Exit GameplayScene");
		}

	}
}