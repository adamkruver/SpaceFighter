// using System;
// using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
// using Sources.Implementation.Controllers;
// using Sources.Implementation.Domain;
// using Sources.Implementation.Presentation.Views;
// using Sources.Implementation.Services.Spaceships;
// using Sources.Interfaces.Domain;
// using Sources.Interfaces.Services.Inputs;
// using Sources.Interfaces.Services.Lifecycles;
// using Sources.Interfaces.Services.Spaceship;
// using Sources.Interfaces.Services.TargetFollowers;
//
// namespace Sources.Implementation.Infrastructure.Factories.Controllers
// {
// 	public class EmptyTargetPresenterFactory
// 	{
// 		private readonly IUpdateService _updateService;
// 		private readonly ICameraFollower _cameraFollower;
// 		private readonly IInputService _inputService;
// 		// private readonly ISpaceshipService _spaceshipService;
// 		
// 		private EmptyTarget _emptyTarget;
// 		private SpaceshipMovementService _spaceshipMovementService;
// 		private readonly ITorqueService _torqueService;
//
// 		public EmptyTargetPresenterFactory(ICameraFollower cameraFollower,
// 			IUpdateService updateService,
// 			IInputService inputService,
// 			// ISpaceshipService spaceshipService,
// 			SpaceshipMovementService spaceshipMovementService,
// 			ITorqueService torqueService)
// 		{
// 			_spaceshipMovementService = spaceshipMovementService ?? throw new ArgumentNullException(nameof(spaceshipMovementService));
// 			_torqueService = torqueService ?? throw new ArgumentNullException(nameof(torqueService));
// 			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
// 			_cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
// 			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
// 			// _spaceshipService = spaceshipService ?? throw new ArgumentNullException(nameof(spaceshipService));
// 		}
//
// 		public EmptyTargetPresenter Create(EmptyTarget emptyTarget, IEmptyTargetView emptyTargetView)
// 		{
// 			if (emptyTargetView == null)
// 				throw new ArgumentNullException(nameof(emptyTargetView));
// 			
// 			_emptyTarget = emptyTarget ?? throw new ArgumentNullException(nameof(emptyTarget));
//
// 			return new EmptyTargetPresenter(
// 				_emptyTarget, 
// 				emptyTargetView,
// 				_cameraFollower, 
// 				_updateService, 
// 				//_spaceshipService,
// 				_inputService,
// 				_spaceshipMovementService,
// 				_torqueService);
// 		}
// 	}
// }