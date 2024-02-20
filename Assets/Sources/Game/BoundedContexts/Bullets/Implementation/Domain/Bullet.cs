using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sources.BoundedContexts.Bullets.Interfaces.Domain;
using Sources.BoundedContexts.Movements.Interfaces.Domain;
using Sources.BoundedContexts.Torques.Interfaces.Domain;
using UnityEngine;

namespace Sources.BoundedContexts.Bullets.Implementation.Domain
{
    public class Bullet : IBullet
    {
        private readonly List<PropertyChangedEventHandler> _listeners = new List<PropertyChangedEventHandler>();

        public Bullet(IMovement movement, IPhysicsTorque physicsTorque)
        {
            Movement = movement ?? throw new ArgumentNullException(nameof(movement));
            Torque = physicsTorque ?? throw new ArgumentNullException(nameof(physicsTorque));
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (_listeners.Count == 0)
                {
                    Movement.PropertyChanged += OnVelocityChanged;
                    Torque.PropertyChanged += OnVelocityChanged;
                }

                _listeners.Add(value);
            }
            remove
            {
                _listeners.Remove(value);

                if (_listeners.Count != 0)
                    return;

                Movement.PropertyChanged -= OnVelocityChanged;
                Torque.PropertyChanged -= OnVelocityChanged;
            }
        }

        public IMovement Movement { get; }

        public IPhysicsTorque Torque { get; }

        public Vector3 Velocity => CalculateVelocity();

        private void OnVelocityChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(IMovement.Position):
                case nameof(IMovement.Speed):
                case nameof(IPhysicsTorque.Rotation):
                    NotifyVelocityChanged();
                    break;
            }
        }

        private void NotifyVelocityChanged() =>
            OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(Velocity)));

        private Vector3 CalculateVelocity() =>
            Torque.Rotation * Movement.Position * Movement.Speed;

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e) =>
            _listeners.ForEach(listener => listener.Invoke(sender, e));
    }
}