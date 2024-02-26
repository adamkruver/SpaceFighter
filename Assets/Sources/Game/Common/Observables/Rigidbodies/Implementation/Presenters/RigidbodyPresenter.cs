﻿using System;
using System.ComponentModel;
using Sources.Common.Observables.Rigidbodies.Implementation.Models;
using Sources.Common.Observables.Rigidbodies.Interfaces.Views;
using Sources.Common.Observables.Transforms.Implementation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;
using UnityEngine;

namespace Sources.Common.Observables.Rigidbodies.Implementation.Presenters
{
	public class RigidbodyPresenter : TransformPresenter
	{
		private readonly ObservableRigidbody _model;
		private readonly IRigidbodyView _view;

		public RigidbodyPresenter(ObservableRigidbody model, IRigidbodyView view, IUpdateService updateService, IFixedUpdateService fixedUpdateService)
			: base(model, view, updateService, fixedUpdateService)
		{
			_model = model ?? throw new ArgumentNullException(nameof(model));
			_view = view ?? throw new ArgumentNullException(nameof(view));
		}

		public override void Enable()
		{
			OnVelocityChanged();
			_model.PropertyChanged += OnModelChanged;
			base.Enable();
		}

		public override void Disable()
		{
			base.Disable();
			_model.PropertyChanged -= OnModelChanged;
		}
		
		private void OnModelChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender is not ObservableRigidbody observableRigidbody)
				return;

			if (e.PropertyName == nameof(ObservableRigidbody.Velocity))
				OnVelocityChanged();
		}

		protected virtual void OnVelocityChanged() => 
			_view.Velocity = _model.Velocity * 200 * Time.fixedDeltaTime;
	}
}