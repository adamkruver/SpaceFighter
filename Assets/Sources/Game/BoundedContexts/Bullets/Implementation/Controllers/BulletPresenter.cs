using System;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.Common.Implememntation;
using Sources.BoundedContexts.ObjectPools;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Controllers
{
	public class BulletPresenter : PresenterBase
	{
		private readonly BulletObjectPool _bulletObjectPool;
		private BulletView _bulletView;

		public BulletPresenter(BulletObjectPool bulletObjectPool, BulletView bulletView)
		{
			_bulletView = bulletView ?? throw new ArgumentNullException(nameof(bulletView));
			_bulletObjectPool = bulletObjectPool ?? throw new ArgumentNullException(nameof(bulletObjectPool));
		}

		public void OnTriggered(Collider collider)
		{
			Debug.Log("Столкновение");
			_bulletObjectPool.ObjectPool.Release(_bulletView);
		}
	}
}