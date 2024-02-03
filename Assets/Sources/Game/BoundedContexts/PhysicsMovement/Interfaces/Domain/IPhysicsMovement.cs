using System;
using UnityEngine;

namespace Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Domain
{
    public interface IPhysicsMovement
    {
        event Action VelocityChanged;
        
        Vector3 Position { get; set; }
        Vector3 Forward { get; set; }
        Vector3 Upward { get; set; }
        
        Vector3 Velocity { get; }

        void SetSpeed(float speed);
    }
}