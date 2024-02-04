using System;
using Sources.Implementation.Domain;
using Sources.Interfaces.Services.Inputs;
using UnityEngine;

namespace Sources.Implementation.Services.Inputs
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