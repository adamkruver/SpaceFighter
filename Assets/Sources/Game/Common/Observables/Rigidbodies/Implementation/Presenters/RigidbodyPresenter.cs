using System;
using System.ComponentModel;
using Sources.Common.Observables.Rigidbodies.Implementation.Models;
using Sources.Common.Observables.Rigidbodies.Interfaces.Views;
using Sources.Common.Observables.Transforms.Implementation.Presenters;
using Sources.Common.StateMachines.Interfaces.Services;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

namespace Sources.Common.Observables.Rigidbodies.Implementation.Presenters
{
	public class RigidbodyPresenter : TransformPresenter
	{
		private readonly ObservableRigidbody _model;
		private readonly IRigidbodyView _view;
		private IFixedUpdateService _fixedUpdateService;
		private Vector3 _direction;


		public RigidbodyPresenter(ObservableRigidbody model, IRigidbodyView view, IUpdateService updateService, IFixedUpdateService fixedUpdateService)
			: base(model, view, updateService, fixedUpdateService)
		{
			_fixedUpdateService = fixedUpdateService;
			_model = model ?? throw new ArgumentNullException(nameof(model));
			_view = view ?? throw new ArgumentNullException(nameof(view));
		}

		public override void Enable()
		{
			OnVelocityChanged();
			_model.PropertyChanged += OnModelChanged;
			_fixedUpdateService.FixedUpdated += OnFixedUpdate;
			base.Enable();
		}

		private void OnFixedUpdate(float delta)
		{
			float halfScreenWidth = Screen.width / 2;
			float halfScreenHeight = Screen.height / 2;
			
			var ray = Camera.main.ScreenPointToRay(new Vector3(halfScreenWidth, halfScreenHeight));
			Physics.Raycast(ray, out RaycastHit hit);
        
			var lookPoint = ray.GetPoint(1000);
        
			// if (hit.distance < 1)
			// 	_direction = lookPoint - _model.Position;
			// else
			// 	_direction = hit.point - _model.Position;

			_direction = lookPoint - _model.Position;

			_model.Rotation = Quaternion.Lerp(
				_model.Rotation,
				Quaternion.LookRotation(_direction),
				delta * 20
			);

			_model.Forward = _view.Forward;
			
			_model.Position = _view.Position;		
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
			_view.Velocity = _model.Velocity;
	}
}