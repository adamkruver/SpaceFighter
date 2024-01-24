using Sources.Game.Interfaces.Controllers;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers
{
	public class PhysicsMovementSystem : MonoBehaviour, IPhysicsMovementSystem
	{
		[SerializeField] private Rigidbody _rigidbody;

		private Vector3 _velocity;

		public Vector3 Position => _rigidbody.position;

		public Vector3 Forward => _rigidbody.transform.forward;

		public Vector3 Upwards => _rigidbody.transform.up;

		public void UpdateFixed(float deltaTime) =>
			_rigidbody.velocity = _velocity;

		public void SetSpeed(float speed) =>
			_velocity = Forward * speed;
	}
}