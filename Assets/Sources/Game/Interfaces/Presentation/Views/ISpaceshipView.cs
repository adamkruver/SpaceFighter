using UnityEngine;

namespace Sources.Game.Interfaces.Presentation.Views
{
    public interface ISpaceshipView
    {
        void SetPosition(Vector3 position);
        void SetDirection(Vector3 direction);
    }
}