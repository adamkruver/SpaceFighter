using Sources.Common.Mvp.Implementation.Views;
using Sources.Common.Mvp.Interfaces;
using Sources.Common.Observables.Transforms.Interfaces.Views;
using UnityEngine;

namespace Sources.Common.Observables.Transforms.Implementation.Views
{
	public class ObservableTransformView<T> : PresentableView<T>, ITransformView
		where T : class, IPresenter
	{
		public Vector3 Position => transform.position;

		public Quaternion Rotation
		{
			get => transform.rotation;
			set => transform.rotation = value;
		}

		public Vector3 Forward => transform.forward;
	}
}