using System;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.Movements.Implementation.Domain.Services;
using Sources.BoundedContexts.Players.Implementation.Models;
using Sources.BoundedContexts.Players.Implementation.Presenters;
using Sources.BoundedContexts.Players.Implementation.Presenters.States;
using Sources.BoundedContexts.Players.Implementation.Presenters.Transitions;
using Sources.BoundedContexts.Players.Interfaces.Views;
using Sources.Common.Observables.Rigidbodies.Implementation.Domain.Services;
using Sources.Common.StateMachines.Implementation.Contexts;
using Sources.Common.StateMachines.Implementation.Decorators;
using Sources.Common.StateMachines.Interfaces.Contexts.States;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Players.Implementation.Factories
{
    public class PlayerPresenterFactory
    {
        private readonly IInputService _inputService;
        private readonly IUpdateService _updateService;
        private readonly MovementService _movementService;
        private readonly RigidbodyMovementService _rigidbodyMovementService;
        private readonly IFixedUpdateService _fixedUpdateService;

        public PlayerPresenterFactory(
            IInputService inputService,
            IUpdateService updateService,
            MovementService movementService,
            RigidbodyMovementService rigidbodyMovementService,
            IFixedUpdateService fixedUpdateService
        )
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
            _rigidbodyMovementService = rigidbodyMovementService ?? throw new ArgumentNullException(nameof(rigidbodyMovementService));
            _fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
        }

        public PlayerPresenter Create(Player model, IPlayerView view)
        {
            ContextStateMachine stateMachine = new ContextStateMachine();

            CameraControlState cameraControlState = new CameraControlState(_inputService);
            SpaceshipControlState spaceshipControlState = new SpaceshipControlState(
                model,
                _inputService,
                _movementService,
                _rigidbodyMovementService,
                _fixedUpdateService,
                _updateService
            );

            var toCameraControlState = new ToCameraControlState(cameraControlState);
            var toSpaceshipControlState = new ToSpaceshipControlState(spaceshipControlState);

            spaceshipControlState.Add(toCameraControlState);
            cameraControlState.Add(toSpaceshipControlState);

            stateMachine.FirstState = spaceshipControlState;

            return new PlayerPresenter(
                model,
                view,
                _updateService,
                stateMachine,
                new UpdatableStateMachine<IContextState>(stateMachine)
            );
        }
    }
}