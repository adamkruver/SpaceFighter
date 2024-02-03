using System;
using Sources.Game.Implementation.Controllers;
using UnityEngine;

namespace Sources.Game.Implementation.Presentation.Views
{
	public class EmptyTargetView : MonoBehaviour
	{
		private SpaceshipCameraPresenter _presenter;

		private void OnEnable() =>
			_presenter?.Enable();

		private void OnDisable() =>
			_presenter?.Disable();

		public void Construct(SpaceshipCameraPresenter presenter)
		{
			if (presenter == null)
				throw new ArgumentNullException(nameof(presenter));

			Hide();
			_presenter = presenter;
			Show();
		}

		public void Hide() =>
			gameObject.SetActive(false);

		public void Show() =>
			gameObject.SetActive(true);
	}
}