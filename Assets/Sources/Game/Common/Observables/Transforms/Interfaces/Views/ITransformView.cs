using UnityEngine;

namespace Sources.Common.Observables.Transforms.Interfaces.Views
{
	public interface ITransformView 
	{
		Quaternion Rotation { get; set; }

		Vector3 Forward { get; }

		Vector3 Position { get; }
	}
}