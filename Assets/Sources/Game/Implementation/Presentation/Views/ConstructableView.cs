using System;
using Sources.BoundedContexts.Common.Interfaces;
using Sources.Interfaces.Presentation.Views;
using UniCtor.Attributes;

namespace Sources.Implementation.Presentation.Views
{
	// public class ConstructableView<TFactory, TPresenter> : PresentableView<TPresenter> 
	// 	where TPresenter : class, IPresenter
	// 	where TFactory : IPresenterFactory<TPresenter>
	// {
	//
	// 	[Constructor]
	// 	private void Construct(TFactory factory)
	// 	{
	// 		Construct(factory.Create());	
	// 	}
	// }
	//
	// public interface IPresenterFactory<T> where T : class, IPresenter
	// {
	// 	T Create(IPresentableView<T> view);
	// } 
}