using Sources.Game.Interfaces.Domain;
using Sources.Game.Interfaces.Services.TargetFollowers;
using UnityEngine;

namespace Sources.Game.Implementation.Domain
{
	public class EmptyTarget : ITarget
	{
		public Vector3 Upwards { get; set; }

		public Vector3 Forward { get; set; }

		public Vector3 Position { get; set; }
	}
}