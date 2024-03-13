using Sources.BoundedContexts.Movements.Implementation.Presenters;
using Sources.BoundedContexts.Movements.Interfaces.Views;
using Sources.Common.Mvp.Implementation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Movements.Implementation.Views
{
    public class PhysicsMovementView : PresentableView<PhysicsMovementPresenter>, IPhysicsMovementView
    {
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 Position => _rigidbody.position;
        private Vector3 Forward => _rigidbody.transform.forward;

        private Vector3 Upward => _rigidbody.transform.up;


        public void UpdateLate(float deltaTime)
        {
            // Presenter.SetPosition(Position);
            // Presenter.SetForward(Forward);
            // Presenter.SetUpward(Upward);
        }
    }
}