using Sources.Implementation.Services.Lifecycles;
using UnityEngine;

namespace Sources.BoundedContexts.PhysicsMovement.Interfaces.Views
{
    public interface IPhysicsMovementView : IFixedUpdateHandler
    {
        void SetVelocity(Vector3 velocity);
    }
}