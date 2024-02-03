using System;
using UnityEngine;

namespace Sources.Game.Implementation.Domain
{
    public struct UserInput
    {
        public UserInput(Vector2 moveDirection, Vector2 cursorPosition, bool isAlterativeCameraMode)
        {
            MoveDirection = moveDirection;
            CursorPosition = cursorPosition;
            IsAlterativeCameraMode = isAlterativeCameraMode;
        }
        
        public Vector2 MoveDirection { get; }
        public Vector2 CursorPosition { get; }

        public bool IsAlterativeCameraMode { get; }
    }
}