using System;
using Sources.BoundedContexts.Bullets.Implementation.Models;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.Common.Observables.Rigidbodies.Implementation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.BoundedContexts.Bullets.Implementation.Controllers
{
	public class BulletPresenter : RigidbodyPresenter
	{
		private readonly Bullet _model;
		private readonly IBulletView _view;

		public BulletPresenter(Bullet model, IBulletView view, IUpdateService updateService, IFixedUpdateService fixedUpdateService)
			: base(model, view, updateService, fixedUpdateService)
		{
			_model = model ?? throw new ArgumentNullException(nameof(model));
			_view = view ?? throw new ArgumentNullException(nameof(view));
		}

		//Todo: public void OnTriggered(Collider collider) тут этого быть не должно 

		// public void OnTriggered(Collider collider)
		// {
		// 	Debug.Log("Столкновение");
		// 	_viewObjectPool.ObjectPool.Release(_view); 
		// }
		//
		// public void UpdateFixed(float deltaTime)
		// {
		// 	
		// }
	}
}