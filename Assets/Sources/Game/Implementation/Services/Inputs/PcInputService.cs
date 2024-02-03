using System;
using Sources.Game.Implementation.Domain;
using Sources.Game.Interfaces.Services.Inputs;
using UnityEngine;
using UnityEngine.UIElements;

namespace Sources.Game.Implementation.Services.Inputs
{
	public class PcInputService : IInputService
	{
		public event Action<bool> CameraModeChanged;
		public UserInput UserInput { get; private set; }

		public void Update(float deltaTime)
		{
			UserInput newUserInput = new UserInput(
				new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
				new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")),
				Input.GetMouseButton(0)
			);

			if (newUserInput.IsAlterativeCameraMode != UserInput.IsAlterativeCameraMode)
				CameraModeChanged?.Invoke(newUserInput.IsAlterativeCameraMode);
			
			UserInput = newUserInput;
		}
	}
}