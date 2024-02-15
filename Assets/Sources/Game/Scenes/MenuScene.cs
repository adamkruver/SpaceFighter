using Sources.Interfaces.Infrastructure.Scenes;
using UnityEngine;

namespace Sources.Scenes
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