using Sources.Game.Implementation.Services.Lifecycles;
using UnityEngine;

namespace Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Views
{
    public interface IPhysicsMovementView : IFixedUpdateHandler
    {
        void SetVelocity(Vector3 velocity);
    }
}