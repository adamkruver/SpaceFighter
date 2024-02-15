using Sources.Extensions.IServiceCollections;
using Sources.Implementation.Services.Scenes;
using Sources.Interfaces.Infrastructure.Scenes;
using Sources.Interfaces.Services.Scenes;
using Sources.Scenes.Factories.Collections;
using UniCtor.Installers;
using UniCtor.Services;

namespace Sources.MonoInstallers
{
    public class InitMonoInstaller : MonoInstaller
    {
        public override void OnConfigure(IServiceCollection services)
        {
            services
                .RegisterAsSingleton<ISceneFactoryProvider, SceneFactoryCollection>()
                .RegisterAsSingleton<ISceneService, ISceneConstructor, SceneService>()
                ;
        }
    }
}