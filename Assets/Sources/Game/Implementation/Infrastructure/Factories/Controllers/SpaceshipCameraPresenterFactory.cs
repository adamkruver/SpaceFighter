using System;
using Sources.Game.Implementation.Controllers;
using Sources.Game.Interfaces.Domain;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Lifecycles;
using Sources.Game.Interfaces.Services.TargetFollowers;

namespace Sources.Game.Implementation.Infrastructure.Factories.Controllers
{
	public class SpaceshipCameraPresenterFactory
	{
		private readonly IUpdateService _updateService;
		private readonly ICameraFollower _cameraFollower;
		private readonly IInputService _inputService;
		private ITarget _empty;
		private ITarget _spaceship;

		public SpaceshipCameraPresenterFactory(IUpdateService updateService, ICameraFollower cameraFollower, IInputService inputService)
		{
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
		}

		public SpaceshipCameraPresenter Create(ITarget empty, ITarget spaceship)
		{
			_empty = empty ?? throw new ArgumentNullException(nameof(empty));
			_spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));

			return new SpaceshipCameraPresenter(_updateService, _cameraFollower, _inputService, _empty, _spaceship);
		}
	}
}