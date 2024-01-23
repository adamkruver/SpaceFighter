using System;
using Sources.Game.Implementation.Infrastructure.StateMachines;
using Sources.Game.Implementation.Infrastructure.StateMachines.Decorators;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Infrastructure.Scenes;
using Sources.Game.Interfaces.Infrastructure.StateMachine;
using Sources.Game.Interfaces.Infrastructure.StateMachine.Factories;
using Sources.Game.Interfaces.Services.SceneServices;

namespace Sources.Game.Implementation.Services.SceneServices
{
	public class SceneService : ISceneService, ISceneSwitcher
	{
		private readonly ISceneFactoryProvider _sceneFactoryProvider;
		private StateMachine<IScene> _stateMachine;
		private IUpdateHandler _updateHandler;

		public SceneService(ISceneFactoryProvider sceneFactoryProvider)
		{
			_sceneFactoryProvider = sceneFactoryProvider ?? throw new ArgumentNullException(nameof(sceneFactoryProvider));
			_stateMachine = new StateMachine<IScene>();

			_updateHandler = new StateMachineUpdatable<IScene>(_stateMachine);
		}

		public void Update(float deltaTime) =>
			_updateHandler.Update(deltaTime);

		public void Change(string sceneName)
		{
			ISceneFactory factory = _sceneFactoryProvider.GetFactory(sceneName);
			IScene state = factory.Create(this);
			_stateMachine.Change(state);
		}
	}
}