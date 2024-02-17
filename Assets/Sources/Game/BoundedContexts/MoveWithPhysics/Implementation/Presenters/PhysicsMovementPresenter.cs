using System;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Views;
using Sources.Common.Mvp.Implememntation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.MoveWithPhysics.Implementation.Presenters
{
    public class PhysicsMovementPresenter : PresenterBase
    {
        private readonly IPhysicsMovement _model;
        private readonly IPhysicsMovementView _view;
        private readonly ILateUpdateService _lateUpdateService;

        public PhysicsMovementPresenter(
            IPhysicsMovement movement,
            IPhysicsMovementView view,
            ILateUpdateService lateUpdateService
        )
        {
            _model = movement ?? throw new ArgumentNullException(nameof(movement));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _lateUpdateService = lateUpdateService ?? throw new ArgumentNullException(nameof(lateUpdateService));
        }

        public override void Enable() => 
            _lateUpdateService.LateUpdated += _view.UpdateLate;

        public override void Disable() => 
            _lateUpdateService.LateUpdated -= _view.UpdateLate;

        public void SetPosition(Vector3 position) =>
            _model.Position = position;

        public void SetForward(Vector3 forward) => 
            _model.Forward = forward;

        public void SetUpward(Vector3 upward) => 
            _model.Upward = upward;
    }
}