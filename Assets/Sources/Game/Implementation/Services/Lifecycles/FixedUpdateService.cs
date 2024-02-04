using System;
using Sources.Interfaces.Services.Lifecycles;

namespace Sources.Implementation.Services.Lifecycles
{
	public class FixedUpdateService : IFixedUpdateService, IFixedUpdateHandler
	{
		public event Action<float> FixedUpdated = delegate {  };

		public void UpdateFixed(float deltaTime) =>
			FixedUpdated.Invoke(deltaTime);
	}
}