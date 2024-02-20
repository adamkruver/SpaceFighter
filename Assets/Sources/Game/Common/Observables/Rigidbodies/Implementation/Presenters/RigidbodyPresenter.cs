using System;
using System.ComponentModel;
using Sources.Common.Observables.Rigidbodies.Implementation.Models;
using Sources.Common.Observables.Rigidbodies.Interfaces.Views;
using Sources.Common.Observables.Transforms.Implementation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.Common.Observables.Rigidbodies.Implementation.Presenters
{
	public class RigidbodyPresenter : TransformPresenter
	{
		private readonly ObservableRigidbody _model;
		private readonly IRigidbodyView _view;

		public RigidbodyPresenter(ObservableRigidbody model, IRigidbodyView view, IUpdateService updateService)
			: base(model, view, updateService)
		{
			_model = model ?? throw new ArgumentNullException(nameof(model));
			_view = view ?? throw new ArgumentNullException(nameof(view));
		}

		public override void Enable()
		{
			OnVelocityChanged();
			base.Enable();
			_model.PropertyChanged += OnModelChanged;
		}

		public override void Disable()
		{
			_model.PropertyChanged -= OnModelChanged;
			base.Disable();
		}
		
		private void OnModelChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender is not ObservableRigidbody observableRigidbody)
				return;

			if (e.PropertyName == nameof(ObservableRigidbody.Velocity))
				OnVelocityChanged();
		}

		private void OnVelocityChanged() =>
			_view.Velocity = _model.Velocity;
	}
}