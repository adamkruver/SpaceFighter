using System;
using Sources.Interfaces.Domain;
using Sources.Interfaces.Services;
using UnityEngine;

namespace Sources.Implementation
{
    public class TargetFollowerService : ICameraLateUpdateHandler, ICameraFollower
    {
        private const float CameraRotateSpeed = 3f;
        private readonly Transform _transform;
        
        private ITarget _target;

        public TargetFollowerService(Transform transform) => 
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));

        public event Action<ITarget> TargetChanged;

        public void Follow(ITarget target)
        {
            _target = target;
            TargetChanged?.Invoke(target);
        }

        public void UpdateLate(float deltaTime)
        {
            if(_target == null)
                return;
            
            _transform.position = _target.Position;

            Quaternion toRotation = Quaternion.LookRotation(_target.Forward, _target.Upward);
            _transform.rotation = Quaternion.Lerp( _transform.rotation, toRotation, CameraRotateSpeed * Time.deltaTime );
        }
    }
}