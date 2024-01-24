using Sources.Game.Interfaces.Controllers;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers
{
    public class PhysicsMovementSystem : MonoBehaviour, IPhysicsMovementSystem
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _torqueBody;

        private Vector3 _velocity;
        private float _torqueForce;

        public Vector3 Position => _rigidbody.position;

        public Vector3 Forward => _rigidbody.transform.forward;

        public Vector3 Up => _rigidbody.transform.up;

        public void UpdateFixed(float deltaTime)
        {
            _rigidbody.velocity = _velocity;
            _rigidbody.transform.forward = Quaternion.AngleAxis(_torqueForce, Vector3.up) * Forward;
            _torqueBody.transform.localRotation = Quaternion.Euler(_torqueForce * 30 * Vector3.back);
        }

        public void SetSpeed(float speed) =>
            _velocity = speed * Forward;

        public void SetTorqueForce(float torqueForce) => 
            _torqueForce = torqueForce;
    }
}