using System;
using System.ComponentModel;
using Sources.Common.Mvp.Implementation.Presenters;
using Sources.Common.Observables.Transforms.Implementation.Models;
using Sources.Common.Observables.Transforms.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;
using UnityEngine;
using Screen = UnityEngine.Device.Screen;

namespace Sources.Common.Observables.Transforms.Implementation.Presenters
{
	public class TransformPresenter : PresenterBase
	{
		private readonly ITransformView _view;
		private readonly IUpdateService _updateService;
		private readonly IFixedUpdateService _fixedUpdateService;
		private readonly ObservableTransform _model;
		private Vector3 _direction;

		public TransformPresenter(ObservableTransform model, ITransformView view, 
			IUpdateService updateService,
			IFixedUpdateService fixedUpdateService)
		{
			_view = view ?? throw new ArgumentNullException(nameof(view));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_fixedUpdateService = fixedUpdateService ?? throw new ArgumentNullException(nameof(fixedUpdateService));
			_model = model ?? throw new ArgumentNullException(nameof(model));
		}

		public override void Enable()
		{
			OnRotationChanged();
			_updateService.Updated += OnUpdatePosition;
			_updateService.Updated += OnUpdateRotation;
			_fixedUpdateService.FixedUpdated += FixedUpdate;
			_model.PropertyChanged += OnModelChanged;
		}

		public override void Disable()
		{
			_model.PropertyChanged -= OnModelChanged;
			_updateService.Updated -= OnUpdateRotation;
			_updateService.Updated -= OnUpdatePosition;
			_fixedUpdateService.FixedUpdated -= FixedUpdate;
		}

		protected virtual void OnUpdatePosition(float deltaTime)
		{
			_model.Position = _view.Position;
		}

		protected virtual void OnUpdateRotation(float deltaTime)
		{
			//_model.Rotation = _view.Rotation;
		}

		/// <summary>
		/// TODO Удрать отсюда
		/// </summary>
		/// <param name="delta"></param>
		private void FixedUpdate(float delta)
		{
			float halfScreenWidth = Screen.width / 2;
			float halfScreenHeight = Screen.height / 2;


			var ray = Camera.main.ScreenPointToRay(new Vector3(halfScreenWidth, halfScreenHeight));
			Physics.Raycast(ray, out RaycastHit hit);
        
			var lookPoint = ray.GetPoint(1000);
        
			if (hit.distance < 1)
				_direction = lookPoint - _model.Position;
			else
				_direction = hit.point - _model.Position;
        
			_model.Rotation = Quaternion.Lerp(
				_model.Rotation,
				Quaternion.LookRotation(_direction),
				delta *20
			);

			_model.Forward = _view.Forward;
			
			_model.Position = _view.Position;
		}

		private void OnModelChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender is not ObservableTransform observableTransform)
				return;

			Action action = e.PropertyName switch
			{
				nameof(ObservableTransform.Rotation) => OnRotationChanged,
				_ => default
			};

			action?.Invoke();
		}

		private void OnRotationChanged()
		{
			_view.Rotation = _model.Rotation;
		}
	}
}