using System;
using Sources.Assets.Implementation;
using Sources.Assets.Interfaces;
using Sources.BoundedContexts.Players.Domain;
using Sources.BoundedContexts.Players.Factories;
using Sources.BoundedContexts.Players.Presentation;
using Sources.Implementation.Domain;
using Sources.Implementation.Infrastructure.Factories.Presentation.Views;
using Sources.Implementation.Services.Lifecycles;
using Sources.Interfaces.Infrastructure.Handlers;
using Sources.Interfaces.Infrastructure.Scenes;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.Services.TargetFollowers;
using UnityEngine;

namespace Sources.Implementation.Controllers.Scenes
{
    public class GameplayScene : IScene, IUpdateHandler, IFixedUpdateHandler, ILateUpdateHandler
    {
        private readonly IInputService _inputService;
        private readonly IUpdateHandler _updateHandler;
        private readonly IUpdateService _updateService;
        private readonly IFixedUpdateHandler _fixedUpdateHandler;
        private readonly ILateUpdateHandler _lateUpdateHandler;
        private readonly ILateUpdateService _lateUpdateService;
        private readonly SpaceshipViewFactory _spaceshipViewFactory;
        //private readonly SpaceshipEmptyTargetViewFactory _spaceshipEmptyTargetViewFactory;
        private readonly ICameraFollower _cameraFollower;
        private readonly ICameraLateUpdateHandler _cameraLateUpdateHandler;
        private readonly IAssetService _assetService;
        private readonly PlayerViewFactory _playerViewFactory;

        public GameplayScene(
            IInputService inputService,
            IUpdateHandler updateHandler,
            IUpdateService updateService,
            IFixedUpdateHandler fixedUpdateHandler,
            ILateUpdateHandler lateUpdateHandler,
            ILateUpdateService lateUpdateService,
            SpaceshipViewFactory spaceshipViewFactory,
            //SpaceshipEmptyTargetViewFactory spaceshipEmptyTargetViewFactory,
            ICameraFollower cameraFollower,
            ICameraLateUpdateHandler cameraLateUpdateHandler,
            IAssetService assetService
        )
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _fixedUpdateHandler = fixedUpdateHandler ?? throw new ArgumentNullException(nameof(fixedUpdateHandler));
            _lateUpdateHandler = lateUpdateHandler ?? throw new ArgumentNullException(nameof(lateUpdateHandler));
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
            _spaceshipViewFactory =
                spaceshipViewFactory ?? throw new ArgumentNullException(nameof(spaceshipViewFactory));
            // _spaceshipEmptyTargetViewFactory = spaceshipEmptyTargetViewFactory ??
            //                                    throw new ArgumentNullException(nameof(spaceshipEmptyTargetViewFactory));
            _cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
            _cameraLateUpdateHandler = cameraLateUpdateHandler ??
                                       throw new ArgumentNullException(nameof(cameraLateUpdateHandler));
            _assetService = assetService ?? throw new ArgumentNullException(nameof(assetService));
            _playerViewFactory = new PlayerViewFactory();
            
        }

        public async void Enter()
        {
            await _assetService.LoadAsync();
            var player = new Player();
            var playerView = _playerViewFactory.Create(player, _spaceshipViewFactory);

            _cameraFollower.Follow(player.Spaceship);

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