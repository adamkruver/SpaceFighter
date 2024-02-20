using System;
using System.ComponentModel;
using Sources.BoundedContexts.Bullets.Implementation.Domain;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.Common.Mvp.Implementation.Presenters;

namespace Sources.BoundedContexts.Bullets.Implementation.Controllers
{
	public class BulletPresenter : PresenterBase
	{
		private readonly Bullet _bullet;
		private readonly IBulletView _bulletView;

		public BulletPresenter(Bullet bullet, IBulletView bulletView)
		{
			_bullet = bullet ?? throw new ArgumentNullException(nameof(bullet));
			_bulletView = bulletView ?? throw new ArgumentNullException(nameof(bulletView));
		}

		public override void Enable()
		{
			OnVelocityChanged();
			_bullet.PropertyChanged += OnModelChanged;
		}

		private void OnModelChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender is Bullet && e.PropertyName == nameof(Bullet.Velocity))
				OnVelocityChanged();
		}

		public override void Disable()
		{
			_bullet.PropertyChanged -= OnModelChanged;
		}

		private void OnVelocityChanged() => 
			_bulletView.SetVelocity(_bullet.Velocity);

		//Todo: public void OnTriggered(Collider collider) тут этого быть не должно 
		// public void OnTriggered(Collider collider)
		// {
		// 	Debug.Log("Столкновение");
		// 	_viewObjectPool.ObjectPool.Release(_bulletView); 
		// }
		//
		// public void UpdateFixed(float deltaTime)
		// {
		// 	
		// }
	}
}