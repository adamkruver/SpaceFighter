using Sources.Game.Implementation.Services.SceneServices;
using Sources.Game.Interfaces.Services.SceneServices;
using Zenject;

public class InitSceneContext : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<ISceneService>().To<SceneService>().AsSingle();
	}
}