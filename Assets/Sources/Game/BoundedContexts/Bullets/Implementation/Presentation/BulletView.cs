using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.BoundedContexts.Movements.Implementation.Views;
using Sources.BoundedContexts.Torques.Implementation.Views;
using Sources.Common.Mvp.Implementation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Presentation
{
	public class BulletView : PresentableView<BulletPresenter>, IBulletView
	{
		[SerializeField] private Rigidbody _rigidbody;

		[field: SerializeField] public PhysicsMovementView MovementView { get; private set; }
		[field: SerializeField] public PhysicsTorqueView TorqueView { get; private set; }

		public void SetVelocity(Vector3 velocity) =>
			_rigidbody.velocity = velocity;
	}
}