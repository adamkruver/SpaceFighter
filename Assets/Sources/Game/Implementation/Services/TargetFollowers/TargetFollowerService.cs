﻿using System;
using Sources.Interfaces.Domain;
using Sources.Interfaces.Services.TargetFollowers;
using UnityEngine;

namespace Sources.Implementation.Services.TargetFollowers
{
    public class TargetFollowerService : ICameraLateUpdateHandler, ICameraFollower
    {
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
            _transform.rotation = Quaternion.LookRotation(_target.Forward, _target.Upward);
        }
    }
    
    // событие по смене наблюдаемого
}