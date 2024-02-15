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
		
		public ViewObjectPool(Func<T> create) 
		{
			//_viewFactory = viewFactory ?? throw new ArgumentNullException(nameof(viewFactory));
			ObjectPool = new ObjectPool<View>(
				create,
				view => view.Show(),
				view => view.Hide(),
				view => view.Destroy(),
				true,
				50,
				10000);
		}
		
		public ObjectPool<View> ObjectPool { get; }
	}
}