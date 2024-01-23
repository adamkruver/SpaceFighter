using System;
using Sources.Game.Implementation.Infrastructure.StateMachines;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Infrastructure.Scenes;
using Sources.Game.Interfaces.Infrastructure.StateMachine;
using Sources.Game.Interfaces.Infrastructure.StateMachine.Factories;
using Sources.Game.Interfaces.Services.SceneServices;

namespace Sources.Game.Implementation.Services.SceneServices
{
	public class SceneService : ISceneService
	{
		private readonly ISceneFactoryProvider _sceneFactoryProvider;
		private IStateMachine<IScene> _stateMachine;

		public SceneService(ISceneFactoryProvider sceneFactoryProvider)
		{
			_sceneFactoryProvider = sceneFactoryProvider ?? throw new ArgumentNullException(nameof(sceneFactoryProvider));
			_stateMachine = new StateMachine<IScene>();
		}

		public void Update(float deltaTime) =>
			(_stateMachine as IUpdateHandler)?.Update(deltaTime);

		public void Change(string sceneName)
		{
			ISceneFactory factory = _sceneFactoryProvider.GetFactory(sceneName);
			IScene state = factory.Create(this);
			_stateMachine.Change(state);
		}
	}
}