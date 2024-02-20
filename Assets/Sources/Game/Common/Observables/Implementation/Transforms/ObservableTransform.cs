using Sources.Common.Mvp.Implementation.Models;
using Sources.Common.Observables.Interfaces.Transforms;
using UnityEngine;

namespace Sources.Common.Observables.Implementation.Transforms
{
    public class ObservableTransform : ObservableModel, IObservableTransform
    {
        private Vector3 _position;
        private Quaternion _rotation;
        private Vector3 _forward;
        private Vector3 _upward;
        private Vector3 _right;

        public Vector3 Position
        {
            get => _position;
            set
            {
                if (TrySetField(ref _position, value) == false)
                    return;

                OnPositionChanged();
            }
        }

        public Vector3 Forward
        {
            get => _forward;
            private set => TrySetField(ref _forward, value);
        }

        public Vector3 Upward
        {
            get => _upward;
            private set => TrySetField(ref _upward, value);
        }

        public Vector3 Right
        {
            get => _right;
            private set => TrySetField(ref _right, value);
        }

        public Quaternion Rotation
        {
            get => _rotation;
            set
            {
                if (TrySetField(ref _rotation, value) == false)
                    return;

                RecalculateAxisVectors();
                OnRotationChanged();
            }
        }

        protected virtual void OnPositionChanged()
        {
        }

        protected virtual void OnRotationChanged()
        {
        }

        private void RecalculateAxisVectors()
        {
            _forward = Rotation * Vector3.forward;
            _right = Rotation * Vector3.right;
            _upward = Rotation * Vector3.up;
        }
    }
}