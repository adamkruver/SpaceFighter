using Sources.Interfaces.Infrastructure.Scenes;
using UnityEngine;

namespace Sources.Implementation.Controllers.Scenes
{
	public class InitScene : IScene
	{
		public void Enter()
		{
			Debug.Log("Enter InitScene");
		}

		public void Exit()
		{
			Debug.Log("Exit InitScene");
		}
	}
}