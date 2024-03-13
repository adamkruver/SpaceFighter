using System;
using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.BoundedContexts.Movements.Interfaces.Views;
using Sources.Common.Mvp.Implementation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.Movements.Implementation.Presenters
{
    public class PhysicsMovementPresenter : PresenterBase
    {
        private readonly IMovement _model;
        private readonly IPhysicsMovementView _view;
        private readonly IUpdateService _updateService;

        public PhysicsMovementPresenter(
            IMovement movement,
            IPhysicsMovementView view,
            IUpdateService updateService
        )
        {
            _model = movement ?? throw new ArgumentNullException(nameof(movement));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
        }

        // public override void Enable() => 
        //     _updateService.Updated += _view.UpdateLate;
        //
        // public override void Disable() => 
        //     _updateService.Updated -= _view.UpdateLate;
        //
        // public void SetPosition(Vector3 position) =>
        //     _model.Position = position;
        //
        // public void SetForward(Vector3 forward) => 
        //     _model.Forward = forward;
        //
        // public void SetUpward(Vector3 upward) => 
        //     _model.Upward = upward;
    }
}