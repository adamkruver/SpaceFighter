using Sources.Game.Implementation.Services.Lifecycles;
using UnityEngine;

namespace Sources.Game.Interfaces.Controllers
{
    public interface IPhysicsMovementSystem : IFixedUpdateHandler
    {
        Vector3 Position { get; }
        Vector3 Forward { get; }
        Vector3 Upwards { get; }
        
        void SetSpeed(float speed);
    }
}