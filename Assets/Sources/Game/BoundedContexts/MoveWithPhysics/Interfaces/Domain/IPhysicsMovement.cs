using System.ComponentModel;
using UnityEngine;

namespace Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain
{
    public interface IPhysicsMovement : INotifyPropertyChanged
    {
        public float Acceleration { get; }

        public float Deceleration { get; }

        public float MaxSpeed { get; }

        public float MinSpeed { get; }

        Vector3 Position { get; set; }

        Vector3 Forward { get; set; }

        Vector3 Upward { get; set; }
        
        float Speed { get; set; }
    }
}