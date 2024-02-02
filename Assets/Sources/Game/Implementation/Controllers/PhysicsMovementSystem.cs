using Sources.Game.Interfaces.Controllers;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers
{
	public class PhysicsMovementSystem : MonoBehaviour, IPhysicsMovementSystem
	{
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField] private float _rotationSpeed;
		
		private Vector3 _velocity;
		private Vector3 _currentRotation;

		public Vector3 Position => _rigidbody.position;

		public Vector3 Forward => _rigidbody.transform.forward;

		public Vector3 Up => _rigidbody.transform.up;

		public void UpdateFixed(float deltaTime) =>
			_rigidbody.velocity = _velocity;

		public void SetSpeed(float speed) =>
			_velocity = speed * Forward;

		public void SetTorqueForce(Vector3 torque)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(torque), _rotationSpeed * Time.deltaTime);
		}
	}
}