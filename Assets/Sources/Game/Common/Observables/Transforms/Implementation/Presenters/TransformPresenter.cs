using System;
using System.ComponentModel;
using Sources.Common.Mvp.Implementation.Presenters;
using Sources.Common.Observables.Transforms.Implementation.Models;
using Sources.Common.Observables.Transforms.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.Common.Observables.Transforms.Implementation.Presenters
{
	public class TransformPresenter : PresenterBase
	{
		private readonly ITransformView _view;
		private readonly IUpdateService _updateService;
		private readonly ObservableTransform _model;

		public TransformPresenter(ObservableTransform model, ITransformView view, IUpdateService updateService)
		{
			_view = view ?? throw new ArgumentNullException(nameof(view));
			_updateService = updateService ?? throw new ArgumentNullException(nameof(updateService));
			_model = model ?? throw new ArgumentNullException(nameof(model));
		}

		public override void Enable()
		{
			OnRotationChanged();
			OnPositionChanged();
			_updateService.Updated += OnUpdate;
			_model.PropertyChanged += OnModelChanged;
		}

		public override void Disable()
		{
			_updateService.Updated -= OnUpdate;
			_model.PropertyChanged -= OnModelChanged;
		}

		private void OnUpdate(float deltaTime)
		{
			_model.Position = _view.Position;
			_model.Rotation = _view.Rotation;
		}

		private void OnModelChanged(object sender, PropertyChangedEventArgs e)
		{
			if (sender is not ObservableTransform observableTransform)
				return;

			Action action = e.PropertyName switch
			{
				nameof(ObservableTransform.Position) => OnPositionChanged,
				nameof(ObservableTransform.Rotation) => OnRotationChanged,
				_ => default
			};

			action?.Invoke();
		}

		private void OnRotationChanged() =>
			_view.Rotation = _model.Rotation;

		private void OnPositionChanged() =>
			_view.Position = _model.Position;
	}
}