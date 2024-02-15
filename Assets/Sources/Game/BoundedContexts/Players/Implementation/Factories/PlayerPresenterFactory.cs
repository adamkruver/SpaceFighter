using System;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain.Services;
using Sources.BoundedContexts.Players.Implementation.Models;
using Sources.BoundedContexts.Players.Implementation.Presenters;
using Sources.BoundedContexts.Players.Implementation.Presenters.States;
using Sources.BoundedContexts.Players.Implementation.Presenters.Transitions;
using Sources.BoundedContexts.Players.Interfaces.Views;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Services;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Services;
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
        private readonly PhysicsMovementService _movementService;
        private readonly PhysicsTorqueService _torqueService;
        private readonly SpaceshipMovementService _spaceshipMovementService;

        public PlayerPresenterFactory(
            IInputService inputService,
            IUpdateService updateService,
            PhysicsMovementService movementService,
            PhysicsTorqueService torqueService
        )
        {
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
            _movementService = movementService ?? throw new ArgumentNullException(nameof(movementService));
            _torqueService = torqueService ?? throw new ArgumentNullException(nameof(torqueService));
        }

        public PlayerPresenter Create(Player model, IPlayerView view)
        {
            ContextStateMachine stateMachine = new ContextStateMachine();

            CameraControlState cameraControlState = new CameraControlState(_inputService);
            SpaceshipControlState spaceshipControlState = new SpaceshipControlState(
                model,
                _inputService,
                _movementService,
                _torqueService
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