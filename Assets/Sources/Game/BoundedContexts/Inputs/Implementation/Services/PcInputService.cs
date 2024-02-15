using Sources.BoundedContexts.Inputs.Implementation.Models;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using UnityEngine;

namespace Sources.BoundedContexts.Inputs.Implementation.Services
{
	public class PcInputService : IInputService
	{
		public InputData InputData { get; private set; }

		public void Update(float deltaTime)
		{
			InputData inputData = new InputData(
				new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")),
				new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")),
				Input.GetMouseButton(1),
				Input.GetKeyUp(KeyCode.Space)
				);

			InputData = inputData;
		}
	}
}