using System;
using System.ComponentModel;
using Sources.BoundedContexts.Torques.Interfaces.Domain;
using Sources.Common.Mvp.Implementation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Torques.Implementation.Domain.Models.Decorators
{
	public class ObservablePhysicsTorque : ObservableModel, IPhysicsTorque
	{
		private readonly INotifyPropertyChanged _notifier;
		private readonly IPhysicsTorque _physicsTorque;

		private Quaternion _rotation;
		private Vector3 _destination;
		private float _rotationSpeed;

		public ObservablePhysicsTorque(INotifyPropertyChanged notifier, IPhysicsTorque physicsTorque)
		{
			_notifier = notifier ?? throw new ArgumentNullException(nameof(notifier));
			_physicsTorque = physicsTorque ?? throw new ArgumentNullException(nameof(physicsTorque));
		}

		public override event PropertyChangedEventHandler PropertyChanged
		{
			add => _notifier.PropertyChanged += value;
			remove => _notifier.PropertyChanged -= value;
		}

		public Quaternion Rotation
		{
			get => _rotation;
			set => TrySetField(ref _rotation, value);
		}

		public Vector3 Destination
		{
			get => _destination;
			set => TrySetField(ref _destination, value);
		}

		public float RotationSpeed
		{
			get => _rotationSpeed;
			set => TrySetField(ref _rotationSpeed, value);
		}
	}
}