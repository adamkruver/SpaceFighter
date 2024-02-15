using System;
using Sources.BoundedContexts.Bullets.Implementation.Factories;
using Sources.Common.Mvp.Implememntation.Views;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace Sources.BoundedContexts.Bullets.Implementation.ObjectPools
{
	public class ViewObjectPool<T> where T : View
	{
		private readonly IViewFactory<T> _viewFactory;

		#region Old Construct
		// private readonly IBulletViewFactory _bulletViewFactory;

		// public ViewObjectPool(IBulletViewFactory bulletViewFactory)
		// {
		// 	_bulletViewFactory = bulletViewFactory ?? throw new ArgumentNullException(nameof(bulletViewFactory));
		// 	
		// 	ObjectPool = new ObjectPool<View>(Create,
		// 		(view) => view.Show(),
		// 		(view) => view.Hide(),
		// 		(view) => Object.Destroy(view),
		// 		true,
		// 		50,
		// 		10000);
		// }
		#endregion
		
		public ViewObjectPool(IViewFactory<T> viewFactory) 
		{
			_viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
			ObjectPool = new ObjectPool<View>(
				_viewFactory.Create,
				view => view.Show(),
				view => view.Hide(),
				view => view.Destroy(),
				true,
				50,
				10000);
		}
		
		public ObjectPool<View> ObjectPool { get; }

		#region MyRegion
		// private BulletView Create() =>
		// 	CreateAsync().GetAwaiter().GetResult();
		//
		// private async UniTask<BulletView> CreateAsync()
		// {
		// 	IBulletView bulletView = await _bulletViewFactory.Create(this);
		// 	return (BulletView)bulletView;
		// }
		#endregion
	}
}