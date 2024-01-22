using System;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Infrastructure.Factories.Presentation.Views;
using Sources.Game.Implementation.Services.Cameras;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Services.Inputs;
using UnityEngine;
using Zenject;

namespace Sources.Game.Implementation.App
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Transform _cameraRoot;

        private IUpdateHandler _updateHandler;
        private IInputService _inputService;
        private SpaceshipViewFactory _spaceshipViewFactory;
        private TargetFollowerService _targetFollowerService;

        private void Update()
        {
            _updateHandler.Update(Time.deltaTime);
            _inputService.Update(Time.deltaTime);
        }

        private void LateUpdate() =>
            _targetFollowerService.UpdateLate(Time.deltaTime);

        [Inject]
        private void Construct(
            IInputService inputService,
            IUpdateHandler updateHandler,
            SpaceshipViewFactory spaceshipViewFactory
        )
        {
            _spaceshipViewFactory =
                spaceshipViewFactory ?? throw new ArgumentNullException(nameof(spaceshipViewFactory));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
            _updateHandler = updateHandler ?? throw new ArgumentNullException(nameof(updateHandler));

            var spaceShip = new Spaceship();

            var spaceshipView = spaceshipViewFactory.Create(spaceShip);

            _targetFollowerService = new TargetFollowerService(_cameraRoot);

            _targetFollowerService.Follow(spaceShip);
        }
    }
}