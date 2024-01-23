using Sources.Game.Interfaces.Infrastructure.StateMachine.Factories;

namespace Sources.Game.Interfaces.Infrastructure.Scenes
{
	public interface ISceneFactoryProvider
	{
		ISceneFactory GetFactory(string sceneName);
	}
}