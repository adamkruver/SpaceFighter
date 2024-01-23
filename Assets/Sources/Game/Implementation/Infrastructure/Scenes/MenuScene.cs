using Sources.Game.Interfaces.Infrastructure.Scenes;
using UnityEngine;

namespace Sources.Game.Implementation.Infrastructure.Scenes
{
	public class MenuScene : IScene
	{
		public void Enter()
		{
			Debug.Log("Enter MenuScene");
		}

		public void Exit()
		{
			Debug.Log("Exit MenuScene");
		}

	}
}