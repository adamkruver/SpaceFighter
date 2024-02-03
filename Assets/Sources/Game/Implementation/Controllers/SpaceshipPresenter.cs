using System;
using Sources.Game.BoundedContexts.Common.Implememntation;
using Sources.Game.Implementation.Controllers.SpaceShipStates;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Services.Spaceships;
using Sources.Game.Interfaces.Domain;
using Sources.Game.Interfaces.Presentation.Views;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Lifecycles;
using Sources.Game.Interfaces.Services.Spaceship;
using Sources.Game.Interfaces.Services.TargetFollowers;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers
{
	public class SpaceshipPresenter : PresenterBase
	{
		private readonly Spaceship _spaceship;
		private readonly ISpaceshipView _spaceshipView;
		private readonly IUpdateService _updateService;
		private readonly IInputService _inputService;
		private readonly SpaceshipMovementService _movementService;
		private readonly ICameraFollower _cameraFollower;
		private readonly ISpaceshipService _spaceshipService;

		public SpaceshipPresenter(Spaceship spaceship,
			ISpaceshipView spaceshipView,
			IUpdateService updateService,
			IInputService inputService,
			SpaceshipMovementService movementService,
			ICameraFollower cameraFollower,
			ISpaceshipService spaceshipService)
		{
			_spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));
			_spaceshipView = spaceshipView ?? throw new ArgumentNullException(nameof(spaceshipView));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
			_cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
			_spaceshipService = spaceshipService ?? throw new ArgumentNullException(nameof(spaceshipService));
		}

		public override void Enable()
		{
			_inputService.CameraModeChanged += OnCameraModeChanged;
			_updateService.Updated += OnUpdate;
			_cameraFollower.TargetChanged += OnCameraTargetChanged;
		}

		public override void Disable()
		{
			_inputService.CameraModeChanged -= OnCameraModeChanged;
			_cameraFollower.TargetChanged -= OnCameraTargetChanged;
			_updateService.Updated -= OnUpdate;
		}

		private void OnCameraModeChanged(bool alterantiveMode)
		{
			if (alterantiveMode == false)
				_cameraFollower.Follow(_spaceship);
		}

		private void OnCameraTargetChanged(ITarget target)
		{
			if (target != _spaceship)
				return;

			_spaceshipService.ChangeState<BattleState>();
		}

		private void OnUpdate(float deltaTime)
		{
			_movementService.AddForce(_spaceship, _inputService.UserInput, deltaTime);
			_movementService.AddTorque(_spaceship, _inputService.UserInput);
		}
	}
}