using System;
using Sources.BoundedContexts.Common.Implememntation;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Views;
using Sources.Interfaces.Services.Lifecycles;
using UnityEngine;

namespace Sources.BoundedContexts.MoveWithPhysics.Implementation.Presenters
{
    public class PhysicsMovementPresenter : PresenterBase
    {
        private readonly IPhysicsMovement _model;
        private readonly IPhysicsMovementView _view;
        private readonly ILateUpdateService _lateUpdateService;
        private readonly IFixedUpdateService _fixedUpdateService;

        public PhysicsMovementPresenter(
            IPhysicsMovement movement,
            IPhysicsMovementView view,
            ILateUpdateService lateUpdateService,
            IFixedUpdateService fixedUpdateService
        )
        {
            _model = movement ?? throw new ArgumentNullException(nameof(movement));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
            _fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
        }

        public override void Enable()
        {
            _lateUpdateService.LateUpdated += _view.UpdateLate;
            _model.VelocityChanged += OnVelocityChanged;
            _fixedUpdateService.FixedUpdated += _view.UpdateFixed;
        }

        public override void Disable()
        {
            _lateUpdateService.LateUpdated -= _view.UpdateLate;
            _model.VelocityChanged -= OnVelocityChanged;
            _fixedUpdateService.FixedUpdated -= _view.UpdateFixed;
        }

        public void SetPosition(Vector3 position) =>
            _model.Position = position;

        public void SetForward(Vector3 forward) => 
            _model.Forward = forward;

        public void SetUpward(Vector3 upward) => 
            _model.Upward = upward;

        private void OnVelocityChanged() => 
            _view.SetVelocity(_model.Velocity);
    }
}