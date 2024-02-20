using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Views;
using Sources.Common.Mvp.Implememntation.Views;
using Unity.VisualScripting;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Presentation
{
	public class BulletView : PresentableView<BulletPresenter>, IBulletView
	{
		[SerializeField] private Rigidbody _rigidbody;
		private float _speed;

		[field: SerializeField] public PhysicsMovementView MovementView { get; private set; }
		[field: SerializeField] public PhysicsTorqueView TorqueView { get; private set; }

		public void SetVelocity(Vector3 velocity) =>
			_rigidbody.velocity = transform.forward * _speed;

		public void SetSpeed(float speed) =>
			_rigidbody.velocity = transform.forward * speed;

		public void SetPosition(Vector3 position) =>
			transform.position = position;
		
		public void SetRotation(Quaternion rotation) =>
			transform.rotation = rotation;
	}
}