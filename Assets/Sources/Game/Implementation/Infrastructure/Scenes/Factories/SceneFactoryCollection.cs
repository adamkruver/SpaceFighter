using System;
using System.Collections.Generic;
using Sources.Game.Interfaces.Infrastructure.Scenes;
using Sources.Game.Interfaces.Infrastructure.StateMachine.Factories;

namespace Sources.Game.Implementation.Infrastructure.Scenes.Factories
{
	public class SceneFactoryCollection : ISceneFactoryProvider
	{
		private readonly Dictionary<string, ISceneFactory> _sceneFactories;

		public SceneFactoryCollection(InitSceneFactory initSceneFactory)
		{
			if (initSceneFactory == null)
				throw new ArgumentNullException(nameof(initSceneFactory));

			_sceneFactories = new Dictionary<string, ISceneFactory>()
			{
				[nameof(InitScene)] = initSceneFactory
			};
		}

		public ISceneFactory GetFactory(string sceneName)
		{
			if (string.IsNullOrWhiteSpace(sceneName))
				throw new ArgumentException("Value cannot be null or whitespace.", nameof(sceneName));

			if (_sceneFactories.TryGetValue(sceneName, out ISceneFactory factory) == false)
				throw new InvalidOperationException(sceneName);

			return factory;
		}
	}
}