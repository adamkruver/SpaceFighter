using System;
using System.ComponentModel;
using Sources.BoundedContexts.Bullets.Implementation.Domain;
using Sources.BoundedContexts.Bullets.Interfaces.Presentation;
using Sources.Common.Mvp.Implememntation.Presenters;

namespace Sources.BoundedContexts.Bullets.Implementation.Controllers
{
	public class BulletPresenter : PresenterBase
	{
		private readonly Bullet _model;
		private readonly IBulletView _view;

		public BulletPresenter(Bullet model, IBulletView view)
		{
			_model = model ?? throw new ArgumentNullException(nameof(model));
			_view = view ?? throw new ArgumentNullException(nameof(view));
		}

		public override void Enable()
		{
			OnVelocityChanged();
			_model.PropertyChanged += OnModelChanged;
		}

		public override void Disable()
		{
			_model.PropertyChanged -= OnModelChanged;
		}

		private void OnModelChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender is Bullet && e.PropertyName == nameof(Bullet.Velocity))
				OnVelocityChanged();
		}

		private void OnVelocityChanged()
		{
			//TODO;
		}
		//_view.SetVelocity(_model.Velocity);

		//Todo: public void OnTriggered(Collider collider) 
	}
}