﻿using Sources.BoundedContexts.PhysicsTorque.Interfaces.Domain;
using UnityEngine;

namespace Sources.Implementation.Domain
{
	public class PhysicsTorque : IPhysicsTorque
	{
		public Quaternion Rotation { get; set; }
		public Vector3 Destination { get; set; }

		public float RotationSpeed { get; } = 2f;
	}
}