using System;
using Sources.Implementation.Controllers.Scenes;
using Sources.Implementation.Infrastructure.Factories.Presentation.Views;
using Sources.Implementation.Services.Lifecycles;
using Sources.Interfaces.Infrastructure.Handlers;
using Sources.Interfaces.Infrastructure.Scenes;
using Sources.Interfaces.Infrastructure.StateMachine.Factories;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.Services.TargetFollowers;

namespace Sources.Implementation.Infrastructure.Factories.Scenes
{
    public class GameplaySceneFactory : ISceneFactory
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

        public GameplaySceneFactory(
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

        public IScene Create(ISceneSwitcher sceneSwitcher) =>
            new GameplayScene(
                _inputService,
                _updateHandler,
                _updateService,
                _fixedUpdateHandler,
                _lateUpdateHandler,
                _lateUpdateService,
                _spaceshipViewFactory,
                _spaceshipEmptyTargetViewFactory,
                _cameraFollower,
                _cameraLateUpdateHandler
            );
    }
}