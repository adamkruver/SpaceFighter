// using System;
// using Sources.BoundedContexts.Common.Implememntation;
// using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
// using Sources.Implementation.Domain;
// using Sources.Implementation.Presentation.Views;
// using Sources.Implementation.Services.Spaceships;
// using Sources.Interfaces.Domain;
// using Sources.Interfaces.Services.Inputs;
// using Sources.Interfaces.Services.Lifecycles;
// using Sources.Interfaces.Services.TargetFollowers;
//
// namespace Sources.Implementation.Controllers
// {
// 	public class EmptyTargetPresenter : PresenterBase
// 	{
// 		private readonly ICameraFollower _cameraFollower;
// 		private readonly IUpdateService _updateService;
// 		//private readonly ISpaceshipService _spaceshipService;
// 		private readonly EmptyTarget _emptyTarget;
// 		private readonly IEmptyTargetView _emptyTargetView;
// 		private readonly IInputService _inputService;
// 		private readonly SpaceshipMovementService _spaceshipMovementService;
// 		private readonly ITorqueService _torqueService;
//
// 		public EmptyTargetPresenter(EmptyTarget target,
// 			IEmptyTargetView emptyTargetView,
// 			ICameraFollower cameraFollower,
// 			IUpdateService updateService,
// 			//ISpaceshipService spaceshipService,
// 			IInputService inputService,
// 			SpaceshipMovementService spaceshipMovementService,
// 			ITorqueService torqueService)
// 		{
// 			_cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
// 			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
// 			_emptyTarget = target ?? throw new ArgumentNullException(nameof(target));
// 			_emptyTargetView = emptyTargetView ?? throw new ArgumentNullException(nameof(emptyTargetView));
// 			//_spaceshipService = spaceshipService ?? throw new ArgumentNullException(nameof(spaceshipService));
// 			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
// 			_spaceshipMovementService = spaceshipMovementService ?? throw new ArgumentNullException(nameof(spaceshipMovementService));
// 			_torqueService = torqueService ?? throw new ArgumentNullException(nameof(torqueService));
// 		}
//
// 		public override void Enable()
// 		{
// 			_updateService.Updated += OnUpdate;
// 			_cameraFollower.TargetChanged += OnTargetChanged;
// 		}
//
// 		public override void Disable()
// 		{
// 			_updateService.Updated -= OnUpdate;
// 			_cameraFollower.TargetChanged -= OnTargetChanged;
// 		}
//
// 		private void OnTargetChanged(ITarget target)
// 		{
// 			if (target != _emptyTarget)
// 				return;
//
// 			//_spaceshipService.ChangeState<FreeLookState>();
// 		}
//
// 		private void OnUpdate(float deltaTime)
// 		{
// 			if (_inputService.InputData.IsAlternativeCameraMode)
// 			{
// 				_emptyTarget.Position = _emptyTargetView.GetPosition();
// 				_emptyTarget.Forward = _emptyTargetView.GetForward();
// 				_emptyTarget.Upward = _emptyTargetView.GetUpward();
// 				
// 				_spaceshipMovementService.AddTorque(_emptyTarget.PhysicsTorque, _inputService.InputData);
// 				_torqueService.UpdateTorqueWithSlerp(_emptyTarget.PhysicsTorque, deltaTime);
//
// 				_emptyTargetView.Rotate(_emptyTarget.PhysicsTorque.Rotation);
// 				
// 				_cameraFollower.Follow(_emptyTarget);
// 			}
// 		}
// 	}
// }