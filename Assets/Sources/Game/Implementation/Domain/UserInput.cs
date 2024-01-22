using UnityEngine;

namespace Sources.Game.Implementation.Domain
{
    public struct UserInput
    {
        public UserInput(Vector2 moveDirection, Vector2 cursorPosition)
        {
            MoveDirection = moveDirection;
            CursorPosition = cursorPosition;
        }

        public Vector2 MoveDirection { get; }
        public Vector2 CursorPosition { get; }
    }
}