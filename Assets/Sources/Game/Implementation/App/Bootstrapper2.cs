using System;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Infrastructure.Factories.Presentation.Views;
using Sources.Game.Implementation.Services.Lifecycles;
using Sources.Game.Implementation.Services.TargetFollowers;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.TargetFollowers;
using UniCtor.Attributes;
using UnityEngine;

namespace Sources.Game.Implementation.App
{
	public class Bootstrapper2 : MonoBehaviour
	{
		private IUpdateHandler _updateHandler;
		private IInputService _inputService;
		private ICameraLateUpdateHandler _cameraLateUpdateHandler;
		private IFixedUpdateHandler _fixedUpdateHandler;

		private void Update()
		{
			_updateHandler.Update(Time.deltaTime);
			_inputService.Update(Time.deltaTime);
		}

		private void FixedUpdate() =>
			_fixedUpdateHandler.UpdateFixed(Time.fixedDeltaTime);

		private void LateUpdate() =>
			_cameraLateUpdateHandler.UpdateLate(Time.deltaTime);

		[Constructor]
		private void Construct(IInputService inputService,
			IUpdateHandler updateHandler,
			IFixedUpdateHandler fixedUpdateHandler,
			SpaceshipViewFactory spaceshipViewFactory,
			SpaceshipEmptyTargetViewFactory spaceshipEmptyTargetViewFactory,
			ICameraFollower cameraFollower,
			ICameraLateUpdateHandler cameraLateUpdateHandler)
		{
			_fixedUpdateHandler = fixedUpdateHandler ?? throw new ArgumentNullException(nameof(fixedUpdateHandler));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));

			var spaceship = new Spaceship();
			var emptyTarget = new EmptyTarget();

			var spaceshipView = spaceshipViewFactory.Create(spaceship);
			
			
			
			var spaceshipEmptyTarget = spaceshipEmptyTargetViewFactory.Create(emptyTarget, spaceship, spaceshipView);

			_cameraLateUpdateHandler = cameraLateUpdateHandler;

			cameraFollower.Follow(spaceship);
		}
	}
}