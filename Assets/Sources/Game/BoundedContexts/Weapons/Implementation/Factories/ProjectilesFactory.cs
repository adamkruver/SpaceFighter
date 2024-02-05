using Sources.BoundedContexts.Weapons.Implementation.Presentation.Projectiles;
using Sources.BoundedContexts.Weapons.Interfaces.Projectiles;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Factories
{
	public class ProjectilesFactory
	{
		public IProjectile Create(Vector3 position, Quaternion rotation) =>
			Object.Instantiate(Resources.Load<ProjectileView>("Views/Projectiles/BlueBall"), position, rotation);
	}
}