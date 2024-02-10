using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Sources.BoundedContexts.ObjectPools
{
	public class BulletObjectPool
	{
		private IBulletViewFactory _bulletViewFactory;

		public ObjectPool<BulletView> ObjectPool { get; }

		public BulletObjectPool(IBulletViewFactory bulletViewFactory)
		{
			_bulletViewFactory = bulletViewFactory;
			ObjectPool = new ObjectPool<BulletView>(Create,
				(bulletView) => bulletView.gameObject.SetActive(true),
				(bulletView) => bulletView.gameObject.SetActive(false),
				(bulletView) => Object.Destroy(bulletView),
				true,
				50,
				10000);
		}

		private BulletView Create() =>
			(BulletView)_bulletViewFactory.Create(this);
	}
}