using UnityEngine;

namespace Sources.BoundedContexts.Inputs.Implementation.Models
{
    public struct InputData
    {
        public InputData(Vector2 moveDirection, Vector2 cursorPosition, bool isAlternativeCameraMode, bool isFire)
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