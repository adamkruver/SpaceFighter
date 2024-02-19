using Sources.BoundedContexts.Bullets.Implementation.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain.Models;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
    public class BulletFactory
    {
        public Bullet Create(Vector3 position, Quaternion rotation, float speed)
        {
            PhysicsMovement movement = new PhysicsMovement(2, 0, speed, 0) // todo : вынести в конфигурацию
            {
                Position = position
            };

            movement.Speed = speed;
            
            PhysicsTorque torque = new PhysicsTorque()
            {
                Rotation = rotation
            };

            return new Bullet(movement, torque);
        }
    }
}