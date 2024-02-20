using Sources.Common.Mvp.Implementation.Models;
using Sources.Common.Observables.Transforms.Implementation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Domain.Models
{
    public class Weapon : ObservableTransform
    {
        private float _lastShootTime;

        public float LastShootTime
        {
            get => _lastShootTime;
            private set => TrySetField(ref _lastShootTime, value);
        }

        public void Shoot() => 
            LastShootTime = Time.time; // TODO Time.time get as parameter outside
    }
}