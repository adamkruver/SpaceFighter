using Sources.BoundedContexts.Bullets.Implementation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
    public class BulletFactory
    {
        public Bullet Create(Vector3 position, Quaternion rotation, float speed, float damage) =>
            new Bullet(damage)
            {
                Speed = speed,
                MinSpeed = 0,
                MaxSpeed = speed,
                Position = position,
                Rotation = rotation,
            };
    }
}