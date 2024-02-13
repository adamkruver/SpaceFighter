using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
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
			CreateAsync().GetAwaiter().GetResult();
		//return UniTask.Run(() => ).GetAwaiter().GetResult();

		private async UniTask<BulletView> CreateAsync()
		{
			IBulletView bulletView = await _bulletViewFactory.Create(this);
			return (BulletView)bulletView;
		}
	}
}