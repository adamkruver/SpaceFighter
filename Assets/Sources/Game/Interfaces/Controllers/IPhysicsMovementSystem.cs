using UnityEngine;

namespace Sources.Game.Interfaces.Controllers
{
    public interface IPhysicsMovementSystem
    {
        Vector3 Position { get; }
        Vector3 Forward { get; }
        Vector3 Upwards { get; }
        
        void AddForce(Vector3 force);

        void SetVelocity(Vector3 velocity);
    }
}