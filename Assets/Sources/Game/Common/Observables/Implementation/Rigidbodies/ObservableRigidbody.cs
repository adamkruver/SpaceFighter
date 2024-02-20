using Sources.Common.Observables.Implementation.Transforms;
using Sources.Common.Observables.Interfaces.Rigidbodies;
using UnityEngine;

namespace Sources.Common.Observables.Implementation.Rigidbodies
{
    public class ObservableRigidbody : ObservableTransform, IObservableRigidbody
    {
        private float _speed;
        private Vector3 _velocity;

        public float MaxSpeed { get; set; }
        public float MinSpeed { get; set; }

        public float Speed
        {
            get => _speed;
            set
            {
                if (TrySetField(ref _speed, value) == false)
                    return;

                CalculateVelocity();
            }
        }

        public Vector3 Velocity
        {
            get => _velocity;
            private set => TrySetField(ref _velocity, value);
        }

        protected override void OnRotationChanged() => 
            CalculateVelocity();

        protected override void OnPositionChanged() => 
            CalculateVelocity();

        private void CalculateVelocity() =>
            Velocity = Rotation * Position * Speed;
    }
}