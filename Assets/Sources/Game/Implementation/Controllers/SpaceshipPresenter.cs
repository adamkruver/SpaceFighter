using System;
using System.ComponentModel;
using Sources.BoundedContexts.Common.Implememntation;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Presenters;
using Sources.Implementation.Domain;
using Sources.Implementation.Services.Spaceships;
using Sources.Interfaces.Domain;
using Sources.Interfaces.Presentation.Views;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.Services.TargetFollowers;
using Sources.Interfaces.SpaceshipStates;

namespace Sources.Implementation.Controllers
{
	public class SpaceshipPresenter : PresenterBase
	{
		private readonly Spaceship _spaceship;
		private readonly ISpaceshipView _spaceshipView;
		private readonly IUpdateService _updateService;
		private readonly IInputService _inputService;
		private readonly SpaceshipMovementService _movementService;
		private readonly ICameraFollower _cameraFollower;
		//private readonly ISpaceshipService _spaceshipService;

		public SpaceshipPresenter(Spaceship spaceship,
			ISpaceshipView spaceshipView,
			IUpdateService updateService,
			IInputService inputService,
			SpaceshipMovementService movementService,
			ICameraFollower cameraFollower
			//ISpaceshipService spaceshipService
			)
		{
			_spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));
			_spaceshipView = spaceshipView ?? throw new ArgumentNullException(nameof(spaceshipView));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
			_cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
			//_spaceshipService = spaceshipService ?? throw new ArgumentNullException(nameof(spaceshipService));
		}

		public override void Enable()
		{
			_spaceship.PropertyChanged += OnModelPropertyChanged;
			_updateService.Updated += OnUpdate;
			_cameraFollower.TargetChanged += OnCameraTargetChanged;
		}

		public override void Disable()
		{
			_spaceship.PropertyChanged -= OnModelPropertyChanged;
			_cameraFollower.TargetChanged -= OnCameraTargetChanged;
			_updateService.Updated -= OnUpdate;
		}

		private void OnCameraTargetChanged(ITarget target)
		{
			// TODO удалить?
			// if (target != _spaceship)
			// 	return;

			//_spaceshipService.ChangeState<BattleState>();
		}

		private void OnUpdate(float deltaTime)
		{
			// главная проверка на нажатие правой кнопки 
			if (_inputService.InputData.IsAlternativeCameraMode == false)
			{
				//_spaceship.CurrentState = new TorqueState(_spaceship, _spaceshipView, _updateService, _inputService, _movementService);
				//_cameraFollower.Follow(_spaceship);
				_movementService.AddForce(_spaceship.Movement, _inputService.InputData.MoveDirection.y, deltaTime);
				_movementService.AddTorque(_spaceship.Torque, _inputService.InputData);
			}
			else
			{
			}
		}

		private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			#region Variant with Action
			// Action<> action;
			//
			// switch (e.PropertyName)
			// {
			// 	case nameof(Spaceship.CurrentState):
			// 		action = OnModelStateChanged;
			// 		break;
			// 	
			// 	default:
			// 		action = null;
			// 		break;
			// }
			//
			// action?.Invoke();
			#endregion
			
			if (sender is not Spaceship spaceship)
				return;

			if (e.PropertyName == nameof(Spaceship.CurrentState))
				OnModelStateChanged(spaceship.CurrentState);
		}

		private void OnModelStateChanged(ISpaceshipState spaceshipCurrentState)
		{
			// if (_torqueStates.TryGetValue(spaceshipCurrentState.GetType(), out ITorqueState torqueState) == false)
			// 	return;
			//
			// _stateMachine.Change(torqueState);
		}
	}
}