using Sources.Common.StateMachines.Interfaces.Handlers;
using UnityEngine;

namespace Sources.BoundedContexts.MoveWithPhysics.Interfaces.Views
{
    public interface IPhysicsMovementView : ILateUpdateHandler, IFixedUpdateHandler
    {
        void SetVelocity(Vector3 velocity);
    }
}