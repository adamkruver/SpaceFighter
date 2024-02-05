using Sources.BoundedContexts.Weapons.Interfaces.Projectiles;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Presentation.Projectiles
{
	public class ProjectileView : MonoBehaviour, IProjectile
	{
		[SerializeField] private Rigidbody _rigidbody;
		public void SetVelocity(Vector3 velocity) =>
			_rigidbody.velocity = velocity;
	}
}