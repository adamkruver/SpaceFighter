using UniCtor.Contexts;

namespace Sources.BoundedContexts.Scenes.Interfaces.Factories
{
	public interface ISceneFactoryProvider
	{
		ISceneFactory GetFactory(string sceneName, ISceneContext sceneContext);
	}
}