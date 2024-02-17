using Sources.BoundedContexts.MoveWithPhysics.Implementation.Presenters;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Views;
using Sources.Common.Mvp.Implememntation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.MoveWithPhysics.Implementation.Views
{
    public class PhysicsMovementView : PresentableView<PhysicsMovementPresenter>, IPhysicsMovementView
    {
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 Position => _rigidbody.position;
        private Vector3 Forward => _rigidbody.transform.forward;

        private Vector3 Upward => _rigidbody.transform.up;


        public void UpdateLate(float deltaTime)
        {
            Presenter.SetPosition(Position);
            Presenter.SetForward(Forward);
            Presenter.SetUpward(Upward);
        }
    }
}