using System;

namespace Sources.Game.Interfaces.Services.Lifecycles
{
	public interface IFixedUpdateService
	{
		public event Action<float> FixedUpdated;
	}
}