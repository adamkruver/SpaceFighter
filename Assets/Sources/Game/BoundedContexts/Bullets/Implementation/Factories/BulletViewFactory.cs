using System;
using Cysharp.Threading.Tasks;
using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Implementation.ObjectPools;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.Common.Mvp.Implememntation.Views;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
	public class BulletViewFactory : IBulletViewFactory<BulletView>
	{
		public async UniTask<IBulletView> Create(ViewObjectPool<BulletView> viewObjectPool)
		{
			//  m_Handle = Addressables.LoadAssetAsync<GameObject>("addressKey");
			GameObject gameObject = await Addressables.InstantiateAsync("PhotonTorpedo").Task;

			if (gameObject.TryGetComponent(out BulletView bulletView) == false)
				throw new InvalidOperationException(nameof(gameObject));

			BulletPresenter bulletPresenter = new BulletPresenter(viewObjectPool, bulletView);

			bulletView.Construct(bulletPresenter);

			return bulletView;
		}

		public BulletView Create()
		{
			throw new NotImplementedException();
		}
	}

	public interface IBulletViewFactory<T> : IViewFactory<T> where T : View
	{
		UniTask<IBulletView> Create(ViewObjectPool<BulletView> viewObjectPool);
	}

	public interface IViewFactory<T> where T : View
	{
		T Create();
	}
}