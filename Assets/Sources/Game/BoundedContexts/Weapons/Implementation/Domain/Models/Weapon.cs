using Sources.BoundedContexts.Weapons.Interfaces.Domain.Models;
using Sources.Common.Mvp.Implememntation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Domain.Models
{
    public class Weapon : ObservableModel, IWeapon
    {
        private float _lastShootTime;
        
        public float Speed { get; private set; }= 10f;

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