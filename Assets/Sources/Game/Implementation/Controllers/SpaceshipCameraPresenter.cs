using System;
using Sources.Game.Interfaces.Domain;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Lifecycles;
using Sources.Game.Interfaces.Services.TargetFollowers;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers
{
	public class SpaceshipCameraPresenter
	{
		private readonly IUpdateService _updateService;
		private readonly ICameraFollower _cameraFollower;
		private readonly IInputService _inputService;
		private readonly ITarget _empty;
		private readonly ITarget _spaceship;

		public SpaceshipCameraPresenter(IUpdateService updateService, ICameraFollower cameraFollower, IInputService inputService, ITarget empty, ITarget spaceship)
		{
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_empty = empty ?? throw new ArgumentNullException(nameof(empty));
			_spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));
		}

		public void Enable()
		{
			_updateService.Updated += UpdateFixed;
		}

		public void Disable()
		{
			_updateService.Updated -= UpdateFixed;
		}

		private void UpdateFixed(float delta)
		{
			if (_inputService.UserInput.IsCameraMode)
				_cameraFollower.Follow(_empty);
			else
				_cameraFollower.Follow(_spaceship);
		}
	}
}