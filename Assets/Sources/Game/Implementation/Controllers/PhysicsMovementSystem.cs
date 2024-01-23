using Sources.Game.Interfaces.Controllers;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers
{
    public class PhysicsMovementSystem : MonoBehaviour, IPhysicsMovementSystem
    {
        [SerializeField] private Rigidbody _rigidbody;
        private Vector3 _velocity;

        public void AddForce(Vector3 force) => 
            _rigidbody.AddForce(force, ForceMode.Impulse);

        public void SetVelocity(Vector3 velocity) =>
            _velocity = velocity;

        private void FixedUpdate() =>
            _rigidbody.velocity = _velocity;

        private void Update() =>
            Debug.Log(_rigidbody.velocity);

        public Vector3 Position => _rigidbody.position;
        
        public Vector3 Forward => _rigidbody.transform.forward;
        public Vector3 Upwards => _rigidbody.transform.up;
    }
}