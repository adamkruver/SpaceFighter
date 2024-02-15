using Sources.BoundedContexts.Scenes.Implementation;
using Sources.BoundedContexts.Scenes.Implementation.Domain.Services;
using Sources.BoundedContexts.Scenes.Implementation.Factories.Collections;
using Sources.BoundedContexts.Scenes.Interfaces;
using Sources.BoundedContexts.Scenes.Interfaces.Factories;
using Sources.BoundedContexts.Scenes.Interfaces.Services;
using Sources.Common.StateMachines.Implementation.Services;
using Sources.Common.StateMachines.Interfaces.Services;
using Sources.Extensions.IServiceCollections;
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