using System;
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
        private readonly SpaceshipEmptyTargetViewFactory _spaceshipEmptyTargetViewFactory;
        private readonly ICameraFollower _cameraFollower;
        private readonly ICameraLateUpdateHandler _cameraLateUpdateHandler;

        public GameplayScene(
            IInputService inputService,
            IUpdateHandler updateHandler,
            IUpdateService updateService,
            IFixedUpdateHandler fixedUpdateHandler,
            ILateUpdateHandler lateUpdateHandler,
            ILateUpdateService lateUpdateService,
            SpaceshipViewFactory spaceshipViewFactory,
            SpaceshipEmptyTargetViewFactory spaceshipEmptyTargetViewFactory,
            ICameraFollower cameraFollower,
            ICameraLateUpdateHandler cameraLateUpdateHandler
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
            _spaceshipEmptyTargetViewFactory = spaceshipEmptyTargetViewFactory ??
                                               throw new ArgumentNullException(nameof(spaceshipEmptyTargetViewFactory));
            _cameraFollower = cameraFollower ?? throw new ArgumentNullException(nameof(cameraFollower));
            _cameraLateUpdateHandler = cameraLateUpdateHandler ??
                                       throw new ArgumentNullException(nameof(cameraLateUpdateHandler));
        }

        public void Enter()
        {
            var spaceship = new Spaceship();
            var emptyTarget = new EmptyTarget(spaceship.Torque);
            var spaceshipView = _spaceshipViewFactory.Create(spaceship);
            var spaceshipEmptyTarget = _spaceshipEmptyTargetViewFactory.Create(emptyTarget, spaceshipView);

            _cameraFollower.Follow(spaceship);

            AddListeners();
        }

        public void Exit()
        {
            RemoveListeners();
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