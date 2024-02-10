using System;
using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.Implementation.Presentation.Views;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Presentation
{
	public class BulletView : PresentableView<BulletPresenter>, IBulletView
	{
		[SerializeField] private Rigidbody _rigidbody;
		public void SetVelocity(Vector3 velocity) =>
			_rigidbody.velocity = velocity;

		public void SetPosition(Vector3 position) =>
			_rigidbody.position = position;

		public void SetForward(Vector3 forward) =>
			transform.forward = forward;

		public void SetRotation(Quaternion rotation) =>
			transform.rotation = rotation;


		private void OnTriggerEnter(Collider other)
		{
			Presenter.OnTriggered(other);
		}
	}
}