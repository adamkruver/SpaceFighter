using UnityEngine;

namespace Sources.Implementation.Domain
{
    public struct UserInput
    {

        public UserInput(Vector2 moveDirection, Vector2 cursorPosition, bool isAlternativeCameraMode, bool isFire)
        {
            MoveDirection = moveDirection;
            CursorPosition = cursorPosition;
            IsAlternativeCameraMode = isAlternativeCameraMode;
            IsFire = isFire;
        }
        
        public Vector2 MoveDirection { get; }
        public Vector2 CursorPosition { get; }

        public bool IsAlternativeCameraMode { get; }

        public bool IsFire { get; }
    }
}