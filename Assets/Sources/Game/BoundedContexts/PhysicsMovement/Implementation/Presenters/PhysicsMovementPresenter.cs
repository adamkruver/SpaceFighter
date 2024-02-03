using System;
using Sources.Game.BoundedContexts.Common.Implememntation;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Domain;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Views;
using Sources.Game.Interfaces.Services.Lifecycles;
using UnityEngine;

namespace Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Presenters
{
    public class PhysicsMovementPresenter : PresenterBase
    {
        private readonly IPhysicsMovement _model;
        private readonly IPhysicsMovementView _view;
        private readonly IFixedUpdateService _fixedUpdateService;

        public PhysicsMovementPresenter(
            IPhysicsMovement movement,
            IPhysicsMovementView view,
            IFixedUpdateService fixedUpdateService
        )
        {
            _model = movement ?? throw new ArgumentNullException(nameof(movement));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
        }

        public override void Enable()
        {
            _fixedUpdateService.FixedUpdated += OnUpdateFixed;
            _model.VelocityChanged += OnVelocityChanged;
        }

        public override void Disable()
        {
            _fixedUpdateService.FixedUpdated -= OnUpdateFixed;
            _model.VelocityChanged -= OnVelocityChanged;
        }

        public void SetPosition(Vector3 position) =>
            _model.Position = position;

        public void SetForward(Vector3 forward) => 
            _model.Forward = forward;

        public void SetUpward(Vector3 upward) => 
            _model.Upward = upward;

        private void OnVelocityChanged() => 
            _view.SetVelocity(_model.Velocity);

        private void OnUpdateFixed(float fixedDeltaTime) => 
            _view.UpdateFixed(fixedDeltaTime);
    }
}