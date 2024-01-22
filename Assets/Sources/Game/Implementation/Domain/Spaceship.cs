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
            set => _speed = Mathf.Clamp(value, -10, 10); // TODO: Remove magic number
        }

        public Vector3 Direction { get; set; } = Vector3.forward;

        public void AddSpeedForce(float moveDirectionY) =>
            Speed += moveDirectionY * 10;
    }
}