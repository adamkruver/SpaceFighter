using Sources.Common.Mvp.Implememntation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Domain.Models
{
    public class Weapon : ObservableModel
    {
        private float _lastShootTime;

        public float Sped { get; private set; } = 3f;

        public float LastShootTime
        {
            get => _lastShootTime;
            private set => TrySetField(ref _lastShootTime, value);
        }

        public void Shoot()
        {
            LastShootTime = Time.time;
        }
    }
}