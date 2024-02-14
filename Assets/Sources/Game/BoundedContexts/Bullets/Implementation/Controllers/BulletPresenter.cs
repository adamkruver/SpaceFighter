using System;
using Sources.BoundedContexts.Bullets.Implementation.ObjectPools;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.Common.Implememntation;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Controllers
{
	public class BulletPresenter : PresenterBase
	{
		private readonly ViewObjectPool<BulletView> _viewObjectPool;
		private BulletView _bulletView;

		public BulletPresenter(ViewObjectPool<BulletView> viewObjectPool, BulletView bulletView)
		{
			_bulletView = bulletView ?? throw new ArgumentNullException(nameof(bulletView));
			_viewObjectPool = viewObjectPool ?? throw new ArgumentNullException(nameof(viewObjectPool));
		}

		public void OnTriggered(Collider collider)
		{
			Debug.Log("Столкновение");
			_viewObjectPool.ObjectPool.Release(_bulletView);
		}
	}
}