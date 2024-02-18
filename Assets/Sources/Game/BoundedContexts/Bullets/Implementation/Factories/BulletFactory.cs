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
            PhysicsMovement movement = new PhysicsMovement(0, 0, float.MaxValue, 0) // todo : вынести в конфигурацию
            {
                Position = position
            };
            
            PhysicsTorque torque = new PhysicsTorque()
            {
                Rotation = rotation
            };

            return new Bullet(movement, torque);
        }
    }
}