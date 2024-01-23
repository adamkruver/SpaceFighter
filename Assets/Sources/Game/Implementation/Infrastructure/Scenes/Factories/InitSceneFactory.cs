using System;
using Sources.Game.Interfaces.Infrastructure.Scenes;
using Sources.Game.Interfaces.Infrastructure.StateMachine.Factories;

namespace Sources.Game.Implementation.Infrastructure.Scenes.Factories
{
	public class InitSceneFactory : ISceneFactory
	{
		public IScene Create(ISceneSwitcher sceneSwitcher) =>
			throw new NotImplementedException();
	}
}