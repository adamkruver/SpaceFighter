using System;

namespace Sources.BoundedContexts.Inputs.Interfaces.Services
{
	public interface IUserInputService : IInputService
	{
		event Action<bool>  CameraModeChanged;
	}
}