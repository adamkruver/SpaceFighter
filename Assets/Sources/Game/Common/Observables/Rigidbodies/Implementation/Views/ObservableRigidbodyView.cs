using Sources.Common.Mvp.Interfaces;
using Sources.Common.Observables.Rigidbodies.Interfaces.Views;
using Sources.Common.Observables.Transforms.Implementation.Views;
using UnityEngine;

namespace Sources.Common.Observables.Rigidbodies.Implementation.Views
{
	[RequireComponent(typeof(Rigidbody))]
	public class ObservableRigidbodyView<T> : ObservableTransformView<T>, IRigidbodyView
	where T : class, IPresenter
	{
		private Rigidbody _rigidbody;

		private void Awake() =>
			_rigidbody = GetComponent<Rigidbody>();

		public Vector3 Velocity
		{
			get => _rigidbody.velocity;
			set => _rigidbody.velocity = value;
		}
	}
}