using System;
using Sources.Game.Interfaces.Services.SceneServices;
using UnityEngine;
using Zenject;

namespace Sources.Game.Implementation.App
{
	public class Bootstrapper : MonoBehaviour
	{
		private ISceneService _sceneService;

		private void Update() =>
			_sceneService.Update(Time.deltaTime);

		[Inject]
		private void Construct(ISceneService sceneService)
		{
			_sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
		}
	}
}