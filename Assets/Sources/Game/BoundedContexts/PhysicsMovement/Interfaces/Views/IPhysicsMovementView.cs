using Sources.Implementation.Services.Lifecycles;
using Sources.Interfaces.Infrastructure.Handlers;
using UnityEngine;

namespace Sources.BoundedContexts.PhysicsMovement.Interfaces.Views
{
    public interface IPhysicsMovementView : ILateUpdateHandler, IFixedUpdateHandler
    {
        void SetVelocity(Vector3 velocity);
    }
}