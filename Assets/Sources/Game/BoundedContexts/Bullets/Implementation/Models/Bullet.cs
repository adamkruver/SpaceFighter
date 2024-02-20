using Sources.BoundedContexts.Bullets.Interfaces.Domain;
using Sources.Common.Observables.Rigidbodies.Implementation.Models;

namespace Sources.BoundedContexts.Bullets.Implementation.Models
{
    public class Bullet : ObservableRigidbody, IBullet
    {
        public Bullet(float damage)
        {
            Damage = damage;
        }

        public float Damage { get; }
    }
}