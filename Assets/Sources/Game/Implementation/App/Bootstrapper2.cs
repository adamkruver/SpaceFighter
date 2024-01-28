using System;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Infrastructure.Factories.Presentation.Views;
using Sources.Game.Implementation.Services.Lifecycles;
using Sources.Game.Implementation.Services.TargetFollowers;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Services.Inputs;
using UniCtor.Attributes;
using UnityEngine;

namespace Sources.Game.Implementation.App
{
    public class Bootstrapper2 : MonoBehaviour
    {
        [SerializeField] private Transform _cameraRoot;

        private IUpdateHandler _updateHandler;
        private IInputService _inputService;
        private SpaceshipViewFactory _spaceshipViewFactory;
        private TargetFollowerService _targetFollowerService;
        private IFixedUpdateHandler _fixedUpdateHandler;

        private void Update()
        {
            _updateHandler.Update(Time.deltaTime);
            _inputService.Update(Time.deltaTime);
        }

        private void FixedUpdate() =>
            _fixedUpdateHandler.UpdateFixed(Time.fixedDeltaTime);

        private void LateUpdate() =>
            _targetFollowerService.UpdateLate(Time.deltaTime);

        [Constructor]
        private void Construct(
            IInputService inputService,
            IUpdateHandler updateHandler,
            IFixedUpdateHandler fixedUpdateHandler,
            SpaceshipViewFactory spaceshipViewFactory)
        {
            _fixedUpdateHandler = fixedUpdateHandler ?? throw new ArgumentNullException(nameof(fixedUpdateHandler));
            _spaceshipViewFactory = spaceshipViewFactory ?? throw new ArgumentNullException(nameof(spaceshipViewFactory));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));

            var spaceShip = new Spaceship();

            var spaceshipView = spaceshipViewFactory.Create(spaceShip);
            
            _targetFollowerService = new TargetFollowerService(_cameraRoot);

            _targetFollowerService.Follow(spaceShip);
        }
    }
}