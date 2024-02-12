using Sources.Implementation.Controllers;
using UnityEngine;

namespace Sources.Implementation.Presentation.Views
{
	public class EmptyTargetView : PresentableView<EmptyTargetPresenter>, IEmptyTargetView
	{
		public Vector3 GetPosition() =>
			transform.position;

		public Vector3 GetUpward() =>
			transform.up;

		public Vector3 GetForward() =>
			transform.forward;

		public void Rotate(Quaternion rotation) =>
			transform.rotation = rotation;
	}

	public interface IEmptyTargetView
	{
		Vector3 GetPosition();

		Vector3 GetUpward();

		Vector3 GetForward();

		void Rotate(Quaternion physicsTorqueRotation);
	}
}