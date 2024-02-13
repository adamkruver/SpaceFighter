using System;
using Cysharp.Threading.Tasks;
using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.BoundedContexts.ObjectPools;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
	public class BulletViewFactory : IBulletViewFactory
	{
		public async UniTask<IBulletView> Create(BulletObjectPool bulletObjectPool)
		{
			AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync("PhotonTorpedo");
			
			await handle.Task;
			
			GameObject gameObject = handle.Result;

			if (gameObject.TryGetComponent(out BulletView bulletView) == false)
				throw new InvalidOperationException(nameof(gameObject));
			
			BulletPresenter bulletPresenter = new BulletPresenter(bulletObjectPool, bulletView);

			bulletView.Construct(bulletPresenter);

			return bulletView;
		}
	}

	public interface IBulletViewFactory
	{
		UniTask<IBulletView> Create(BulletObjectPool bulletObjectPool);
	}
}