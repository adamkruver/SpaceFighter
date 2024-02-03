﻿using System;
using Sources.Game.BoundedContexts.Common.Implememntation;
using Sources.Game.Implementation.Controllers.SpaceShipStates;
using Sources.Game.Interfaces.Domain;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Spaceship;
using Sources.Game.Interfaces.Services.TargetFollowers;

namespace Sources.Game.Implementation.Controllers
{
	public class EmptyTargetPresenter : PresenterBase
	{
		private readonly ICameraFollower _cameraFollower;
		private readonly ISpaceshipService _spaceshipService;
		private readonly ITarget _target;
		private readonly IInputService _inputService;

		public EmptyTargetPresenter(ITarget target, ICameraFollower cameraFollower, ISpaceshipService spaceshipService, IInputService inputService)
		{
			_cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
			_target = target ?? throw new ArgumentNullException(nameof(target));
			_spaceshipService = spaceshipService ?? throw new ArgumentNullException(nameof(spaceshipService));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
		}

		public override void Enable()
		{
			_cameraFollower.TargetChanged += OnTargetChanged;
			_inputService.CameraModeChanged += OnCameraModeChanged;
		}

		public override void Disable()
		{
			_inputService.CameraModeChanged -= OnCameraModeChanged;
			_cameraFollower.TargetChanged -= OnTargetChanged;
		}

		private void OnCameraModeChanged(bool alterantiveMode)
		{
			if (alterantiveMode)
				_cameraFollower.Follow(_target);
		}

		private void OnTargetChanged(ITarget target)
		{
			if (target != _target)
				return;

			_spaceshipService.ChangeState<FreeLookState>();
		}
	}
}