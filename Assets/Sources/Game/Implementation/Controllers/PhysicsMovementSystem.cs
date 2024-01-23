using Sources.Game.Interfaces.Controllers;
using UnityEngine;

namespace Sources.Game.Implementation.Controllers
{
    public class PhysicsMovementSystem : MonoBehaviour, IPhysicsMovementSystem
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void AddForce(Vector3 force) => 
            _rigidbody.AddForce(force, ForceMode.Impulse);

        public Vector3 Position => _rigidbody.position;
        
        public Vector3 Forward => _rigidbody.transform.forward;
        public Vector3 Upwards => _rigidbody.transform.up;
    }
}