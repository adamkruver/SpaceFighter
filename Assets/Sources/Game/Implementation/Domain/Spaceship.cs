using UnityEngine;

namespace Sources.Game.Implementation.Domain
{
    public class Spaceship
    {
        private float _speed;

        public Vector3 Position { get; set; }

        public float Speed
        {
            get => _speed;
            set => _speed = Mathf.Clamp(value, -100, 100); // TODO: Remove magic number
        }

        public float Acceleration { get; set; } = 100f;
        public Vector3 Forward { get; set; }
        public Vector3 Upwards { get; set; }
    }
}