using System;
using Sources.Game.Implementation.Domain;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using UnityEngine;

namespace Sources.Game.Implementation.Services.TargetFollowers
{
    public class TargetFollowerService : ILateUpdateHandler
    {
        private readonly Transform _transform;
        
        private Spaceship _spaceship;

        public TargetFollowerService(Transform transform) => 
            _transform = transform ? transform : throw new ArgumentNullException(nameof(transform));

        public void Follow(Spaceship spaceship) => 
            _spaceship = spaceship ?? throw new ArgumentNullException(nameof(spaceship));

        public void UpdateLate(float deltaTime)
        {
            if(_spaceship == null)
                return;
            
            _transform.position = _spaceship.Position;
            _transform.rotation = Quaternion.LookRotation(_spaceship.Forward, _spaceship.Upwards);
        }
    }
}