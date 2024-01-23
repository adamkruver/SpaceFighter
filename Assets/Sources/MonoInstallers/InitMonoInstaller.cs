using Sources.Game.Implementation.Infrastructure.Scenes.Factories;
using Sources.Game.Implementation.Infrastructure.StateMachines;
using Sources.Game.Implementation.Services.SceneServices;
using Sources.Game.Interfaces.Infrastructure.Scenes;
using Sources.Game.Interfaces.Infrastructure.StateMachine;
using Sources.Game.Interfaces.Services.SceneServices;
using Zenject;

public class InitMonoInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		Container.Bind<InitSceneFactory>().AsSingle();
		Container.Bind<ISceneFactoryProvider>().To<SceneFactoryCollection>().AsSingle();
		Container.BindInterfacesAndSelfTo<SceneService>().AsSingle();
	}
}