using System;
using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.Common.Mvp.Implementation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Weapons.Implementation.Domain.Models
{
    public class Weapon : ObservableModel
    {

        private float _lastShootTime;

        public float LastShootTime
        {
            get => _lastShootTime;
            private set => TrySetField(ref _lastShootTime, value);
        }

        public void Shoot() => 
            LastShootTime = Time.time;
    }
}