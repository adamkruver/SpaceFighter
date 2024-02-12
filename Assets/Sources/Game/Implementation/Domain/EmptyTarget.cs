using System;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.Interfaces.Domain;
using UnityEngine;

namespace Sources.Implementation.Domain
{
	public class EmptyTarget : ITarget
	{
		public EmptyTarget(IPhysicsTorque physicsTorque) =>
			PhysicsTorque = physicsTorque;

		public IPhysicsTorque PhysicsTorque { get; }
		public Vector3 Upward { get; set; }

		public Vector3 Forward { get; set;}

		public Vector3 Position { get; set;}
	}
}