using System;
using Sources.Game.Interfaces.Services.Lifecycles;

namespace Sources.Game.Implementation.Services.Lifecycles
{
	public class FixedUpdateService : IFixedUpdateService, IFixedUpdateHandler
	{
		public event Action<float> FixedUpdated = delegate {  };

		public void UpdateFixed(float deltaTime) =>
			FixedUpdated.Invoke(deltaTime);
	}
}