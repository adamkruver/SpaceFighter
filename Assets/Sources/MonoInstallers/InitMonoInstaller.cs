using Sources.Game.Implementation.Infrastructure.Scenes.Factories;
using Sources.Game.Implementation.Services.SceneServices;
using Sources.Game.Interfaces.Infrastructure.Scenes;
using Sources.Game.Interfaces.Services.SceneServices;
using UniCtor.Installers;
using UniCtor.Services;

namespace Sources.MonoInstallers
{
	public class InitMonoInstaller : MonoInstaller
	{
		public override void OnConfigure(IServiceCollection services)
		{
			services
				.RegisterAsSingleton<ISceneFactoryProvider,SceneFactoryCollection>()
				.RegisterAsSingleton<ISceneService,SceneService>()
				;
			
		}
	}
}