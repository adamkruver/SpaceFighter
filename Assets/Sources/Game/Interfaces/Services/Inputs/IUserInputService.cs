using System;
using Sources.Implementation.Domain;

namespace Sources.Interfaces.Services.Inputs
{
	public interface IUserInputService : IInputService
	{
		event Action<bool>  CameraModeChanged;
	}
}