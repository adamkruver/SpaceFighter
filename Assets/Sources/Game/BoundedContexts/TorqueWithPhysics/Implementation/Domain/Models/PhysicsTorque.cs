﻿using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Domain;
using Sources.Common.Mvp.Implememntation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.TorqueWithPhysics.Implementation.Domain.Models
{
    public class PhysicsTorque : ObservableModel, IPhysicsTorque
    {
        private Quaternion _rotation;
        private Vector3 _destination;

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

        public float RotationSpeed { get; } = 2f;
    }
}