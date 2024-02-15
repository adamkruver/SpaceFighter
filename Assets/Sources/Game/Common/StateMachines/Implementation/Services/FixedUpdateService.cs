using System;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.Services;

namespace Sources.Common.StateMachines.Implementation.Services
{
	public class FixedUpdateService : IFixedUpdateService, IFixedUpdateHandler
	{
		public event Action<float> FixedUpdated = delegate {  };

		public void UpdateFixed(float deltaTime) =>
			FixedUpdated.Invoke(deltaTime);
	}
}