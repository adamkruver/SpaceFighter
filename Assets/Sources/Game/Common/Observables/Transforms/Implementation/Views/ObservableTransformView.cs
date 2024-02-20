using Sources.Common.Mvp.Implementation.Views;
using Sources.Common.Mvp.Interfaces;
using Sources.Common.Observables.Transforms.Interfaces.Views;
using Sources.Common.StateMachines.Interfaces.Handlers;
using UnityEngine;

namespace Sources.Common.Observables.Transforms.Implementation.Views
{
	public class ObservableTransformView<T> : PresentableView<T>, ITransformView
		where T : class, IPresenter 
	{
		public Vector3 Position
		{
			get => transform.position;
			set => transform.position = value;
		}

		public Quaternion Rotation
		{
			get => transform.rotation;
			set => transform.rotation = value;
		}
	}
}