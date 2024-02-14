using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.Interfaces.Domain;
using Sources.Interfaces.SpaceshipStates;
using UnityEngine;

namespace Sources.Implementation.Domain
{
	public class Spaceship : ObservableModel, ITarget
	{
		private const float Acceleration = 5f;
		private const float Deceleration = 2f;
		private const float MaxSpeed = 50f;
		private const float MinSpeed = 0f;

		private ISpaceshipState _state;

		public Spaceship()
		{
			Torque = new ObservablePhysicsTorque(this, new PhysicsTorque());
			Movement = new PhysicsMovement(Acceleration, Deceleration, MaxSpeed, MinSpeed);
		}

		public ISpaceshipState CurrentState
		{
			get => _state;

			set => TrySetField(ref _state, value);
		}

		public IPhysicsMovement Movement { get; }

		public ObservablePhysicsTorque Torque { get; }

		public float MouseSensitivity { get; } = 2f;

		public Vector3 Upward => Movement.Upward;

		public Vector3 Forward => Movement.Forward;

		public Vector3 Position => Movement.Position;
	}
}