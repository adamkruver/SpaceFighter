using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.BoundedContexts.ObjectPools;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
	public class BulletViewFactory : IBulletViewFactory
	{
		public IBulletView Create(Vector3 position, Quaternion rotation)
		{
			return Object.Instantiate(Resources.Load<BulletView>("Views/Projectiles/PhotonTorpedo"), position, rotation);
		}

		public IBulletView Create(BulletObjectPool bulletObjectPool)
		{
			BulletView view = Object.Instantiate(Resources.Load<BulletView>("Views/Projectiles/PhotonTorpedo"));
			BulletPresenter bulletPresenter = new BulletPresenter(bulletObjectPool, view);

			view.Construct(bulletPresenter);
			
			return view;
		}
	}

	public interface IBulletViewFactory
	{
		IBulletView Create(Vector3 position, Quaternion rotation);

		IBulletView Create(BulletObjectPool bulletObjectPool);
	}
}