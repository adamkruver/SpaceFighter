using System;
using Sources.BoundedContexts.Assets.Interfaces;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.Players.Implementation.Factories;
using Sources.BoundedContexts.Scenes.Interfaces;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.Services;
using Sources.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.Scenes.Implementation.Domain.Models
{
	public class GameplayScene : IScene, IUpdateHandler, IFixedUpdateHandler, ILateUpdateHandler
	{
		private readonly IInputService _inputService;
		private readonly IUpdateHandler _updateHandler;
		private readonly IUpdateService _updateService;
		private readonly IFixedUpdateHandler _fixedUpdateHandler;
		private readonly ILateUpdateHandler _lateUpdateHandler;
		private readonly ILateUpdateService _lateUpdateService;
		private readonly ICameraFollower _cameraFollower;
		private readonly ICameraLateUpdateHandler _cameraLateUpdateHandler;
		private readonly IAssetService _assetService;
		private readonly PlayerFactory _playerFactory;
		private readonly PlayerViewFactory _playerViewFactory;
		private readonly IFixedUpdateService _fixedUpdateService;
		private readonly CameraController _cameraController;

		public GameplayScene(IInputService inputService,
			IUpdateHandler updateHandler,
			IUpdateService updateService,
			IFixedUpdateHandler fixedUpdateHandler,
			ILateUpdateHandler lateUpdateHandler,
			ILateUpdateService lateUpdateService,
			ICameraFollower cameraFollower,
			ICameraLateUpdateHandler cameraLateUpdateHandler,
			IAssetService assetService,
			PlayerFactory playerFactory,
			PlayerViewFactory playerViewFactory,
			CameraController cameraController,
			IFixedUpdateService fixedUpdateService)
		{
			_inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
			_updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_fixedUpdateHandler = fixedUpdateHandler ?? throw new ArgumentNullException(nameof(fixedUpdateHandler));
			_lateUpdateHandler = lateUpdateHandler ?? throw new ArgumentNullException(nameof(lateUpdateHandler));
			_lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
			_cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
			_cameraLateUpdateHandler = cameraLateUpdateHandler ??
			                           throw new ArgumentNullException(nameof(cameraLateUpdateHandler));
			_assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
			_playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
			_playerViewFactory = playerViewFactory ?? throw new ArgumentNullException(nameof(playerViewFactory));
			_fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
			_cameraController = cameraController ? cameraController : throw new ArgumentNullException(nameof(cameraController));
		}

		public async void Enter()
		{
			await _assetService.LoadAsync();

			var player = _playerFactory.Create();
			_playerViewFactory.Create(player);

			_cameraController.Construct(player.Spaceship, _lateUpdateService);

			AddListeners();
		}

		public void Exit()
		{
			RemoveListeners();
			_assetService.Release();
		}

		public void Update(float deltaTime) =>
			_updateHandler.Update(deltaTime);

		public void UpdateFixed(float deltaTime) =>
			_fixedUpdateHandler.UpdateFixed(deltaTime);

		public void UpdateLate(float deltaTime) =>
			_lateUpdateHandler.UpdateLate(deltaTime);

		private void AddListeners()
		{
			_updateService.Updated += _inputService.Update;
			_lateUpdateService.LateUpdated += _cameraLateUpdateHandler.UpdateLate;
		}

		private void RemoveListeners()
		{
			_updateService.Updated -= _inputService.Update;
			_lateUpdateService.LateUpdated -= _cameraLateUpdateHandler.UpdateLate;
		}
	}
}