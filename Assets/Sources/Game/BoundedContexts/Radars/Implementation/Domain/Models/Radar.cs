using Sources.Common.Mvp.Implementation.Models;
using UnityEngine;

namespace Sources.BoundedContexts.Radars.Implementation.Domain.Models
{
    public class Radar : ObservableModel
    {
        private Vector3 _position;
        private float _radius;

        public Vector3 Position
        {
            get => _position;
            set => TrySetField(ref _position, value);
        }

        public float Radius
        {
            get => _radius;
            set => TrySetField(ref _radius, value);
        }
    }
}