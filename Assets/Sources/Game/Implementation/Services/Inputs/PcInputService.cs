using Sources.Game.Implementation.Domain;
using Sources.Game.Interfaces.Services.Inputs;
using UnityEngine;

namespace Sources.Game.Implementation.Services.Inputs
{
    public class PcInputService : IInputService
    {
        public UserInput UserInput { get; private set; }

        public void Update(float deltaTime)
        {
            UserInput = new UserInput(
                new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
                Input.mousePosition
            );
        }
    }
}