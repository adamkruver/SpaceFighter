using UnityEngine;

namespace Sources.Game.Implementation.Domain
{
    public struct UserInput
    {
        public UserInput(Vector2 moveDirection, Vector2 cursorPosition, bool isCameraMode)
        {
            MoveDirection = moveDirection;
            CursorPosition = cursorPosition;
            IsCameraMode = isCameraMode;
        }

       
        public Vector2 MoveDirection { get; }
        public Vector2 CursorPosition { get; }
        public bool IsCameraMode { get; }
    }
}