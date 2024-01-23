using Sources.Game.Implementation.Infrastructure.Scenes.Factories;
using Sources.Game.Implementation.Services.SceneServices;
using Sources.Game.Interfaces.Infrastructure.Scenes;
using Zenject;

namespace Sources.MonoInstallers
{
	public class InitMonoInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.Bind<InitSceneFactory>().AsSingle();
			Container.Bind<ISceneFactoryProvider>().To<SceneFactoryCollection>().AsSingle();
			Container.BindInterfacesAndSelfTo<SceneService>().AsSingle();
		}
	}
}