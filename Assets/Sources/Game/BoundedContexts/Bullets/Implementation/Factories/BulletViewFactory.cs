using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
	public class BulletViewFactory : IBulletViewFactory
	{
		public IBulletView Create(Vector3 position, Quaternion rotation)
		{
			return Object.Instantiate(Resources.Load<BulletView>("Views/Projectiles/PhotonTorpedo"), position, rotation);
		}
	}

	public interface IBulletViewFactory
	{
		IBulletView Create(Vector3 position, Quaternion rotation);
	}
}