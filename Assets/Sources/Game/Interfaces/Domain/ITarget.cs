using UnityEngine;

namespace Sources.Game.Interfaces.Domain
{
	public interface ITarget
	{
		Vector3 Upward { get; }

		Vector3 Forward { get; }

		Vector3 Position { get; }
	}
}