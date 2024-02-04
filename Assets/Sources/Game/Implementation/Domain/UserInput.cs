using UnityEngine;

namespace Sources.Implementation.Domain
{
    public struct UserInput
    {
        public UserInput(Vector2 moveDirection, Vector2 cursorPosition, bool isAlternativeCameraMode)
        {
            MoveDirection = moveDirection;
            CursorPosition = cursorPosition;
            IsAlternativeCameraMode = isAlternativeCameraMode;
        }
        
        public Vector2 MoveDirection { get; }
        public Vector2 CursorPosition { get; }

        public bool IsAlternativeCameraMode { get; }
    }
}