using System;
using Sources.Interfaces.Domain;
using UnityEngine;

namespace Sources.Implementation.Domain
{
	public class EmptyTarget : ITarget
	{
		private readonly ITarget _target;

		public EmptyTarget(ITarget target) =>
			_target = target ?? throw new ArgumentNullException(nameof(target));

		public Vector3 Upward => _target.Upward;

		public Vector3 Forward => _target.Forward;

		public Vector3 Position => _target.Position;
	}
}