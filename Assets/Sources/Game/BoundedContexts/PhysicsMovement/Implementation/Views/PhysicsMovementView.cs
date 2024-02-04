using Sources.BoundedContexts.PhysicsMovement.Implementation.Presenters;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Views;
using Sources.Implementation.Presentation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.PhysicsMovement.Implementation.Views
{
    public class PhysicsMovementView : PresentableView<PhysicsMovementPresenter>, IPhysicsMovementView
    {
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 _velocity;

        private Vector3 Position => _rigidbody.position;
        private Vector3 Forward => _rigidbody.transform.forward;
        private Vector3 Upward => _rigidbody.transform.up;

        public void SetVelocity(Vector3 velocity) =>
            _velocity = velocity;

        public void UpdateFixed(float fixedDeltaTime) =>
            _rigidbody.velocity = _velocity;

        public void UpdateLate(float deltaTime)
        {
            Presenter.SetPosition(Position);
            Presenter.SetForward(Forward);
            Presenter.SetUpward(Upward);
        }
    }
}