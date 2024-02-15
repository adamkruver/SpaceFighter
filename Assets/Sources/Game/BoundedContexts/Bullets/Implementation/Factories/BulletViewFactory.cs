using System;
using Sources.BoundedContexts.Assets.Implementation;
using Sources.BoundedContexts.Bullets.Implementation.Controllers;
using Sources.BoundedContexts.Bullets.Implementation.ObjectPools;
using Sources.BoundedContexts.Bullets.Implementation.Presentation;
using Sources.Common.Mvp.Implememntation.Views;
using Object = UnityEngine.Object;

namespace Sources.BoundedContexts.Bullets.Implementation.Factories
{
	public class BulletViewFactory : IViewFactory<BulletView>
	{
		private readonly BulletAssetProvider _bulletAssetProvider;
		private readonly ViewObjectPool<BulletView> _viewObjectPool;

		public BulletViewFactory(BulletAssetProvider bulletAssetProvider, ViewObjectPool<BulletView> viewObjectPool)
		{
			_bulletAssetProvider = bulletAssetProvider ?? throw new ArgumentNullException(nameof(bulletAssetProvider));
			_viewObjectPool = viewObjectPool ?? throw new ArgumentNullException(nameof(viewObjectPool));
		}

		public BulletView Create()
		{
			BulletView bulletView = Object.Instantiate(_bulletAssetProvider.View);

			BulletPresenter bulletPresenter = new BulletPresenter(_viewObjectPool, bulletView);

			bulletView.Construct(bulletPresenter);

			return bulletView;
		}
	}

	public interface IViewFactory<T> where T : View
	{
		T Create();
	}
}