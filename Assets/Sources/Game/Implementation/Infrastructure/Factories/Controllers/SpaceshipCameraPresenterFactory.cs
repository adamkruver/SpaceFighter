using System;
using Sources.Game.Implementation.Controllers;
using Sources.Game.Interfaces.Domain;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Lifecycles;
using Sources.Game.Interfaces.Services.Spaceship;
using Sources.Game.Interfaces.Services.TargetFollowers;

namespace Sources.Game.Implementation.Infrastructure.Factories.Controllers
{
	public class SpaceshipCameraPresenterFactory
	{
		private readonly IUpdateService _updateService;
		private readonly ICameraFollower _cameraFollower;
		private readonly IInputService _inputService;
		private readonly ISpaceshipService _spaceshipService;
		private ITarget _empty;

		public SpaceshipCameraPresenterFactory(IUpdateService updateService, ICameraFollower cameraFollower, IInputService inputService, ISpaceshipService spaceshipService)
		{
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_spaceshipService = spaceshipService ?? throw new ArgumentNullException(nameof(spaceshipService));
		}

		public EmptyTargetPresenter Create(ITarget empty)
		{
			_empty = empty ?? throw new ArgumentNullException(nameof(empty));

			return new EmptyTargetPresenter(_empty,  _cameraFollower,  _spaceshipService, _inputService);
		}
	}
}