using UnityEngine;

namespace Sources.Interfaces.Domain
{
	public interface ITarget
	{
		Vector3 Upward { get; }

		Vector3 Forward { get; }

		Vector3 Position { get; }
	}
}