using Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Presenters;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Views;
using Sources.Game.Implementation.Presentation.Views;
using UnityEngine;

namespace Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Views
{
    public class PhysicsMovementView : PresentableView<PhysicsMovementPresenter>, IPhysicsMovementView
    {
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 _velocity;

        private Vector3 Position => _rigidbody.position;
        private Vector3 Forward => _rigidbody.transform.forward;
        private Vector3 Upward => _rigidbody.transform.up;

        public void UpdateFixed(float deltaTime)
        {
            _rigidbody.velocity = _velocity;
            
            Presenter.SetPosition(Position);
            Presenter.SetForward(Forward);
            Presenter.SetUpward(Upward);
        }

        public void SetVelocity(Vector3 velocity) =>
            _velocity = velocity;
    }
}