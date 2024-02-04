using Sources.Interfaces.Infrastructure.StateMachine.Factories;
using UniCtor.Contexts;

namespace Sources.Interfaces.Infrastructure.Scenes
{
	public interface ISceneFactoryProvider
	{
		ISceneFactory GetFactory(string sceneName, ISceneContext sceneContext);
	}
}