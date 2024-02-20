using Sources.Common.Observables.Transforms.Interfaces.Views;
using UnityEngine;

namespace Sources.Common.Observables.Rigidbodies.Interfaces.Views
{
	public interface IRigidbodyView :  ITransformView
	{
		Vector3 Velocity { get; set; }
	}
}