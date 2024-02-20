using UnityEngine;

namespace Sources.Common.Observables.Transforms.Interfaces.Views
{
	public interface ITransformView 
	{
		Vector3 Position { get; set; }

		Quaternion Rotation { get; set; }
	}
}