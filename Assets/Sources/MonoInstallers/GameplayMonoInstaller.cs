using Sources.Game.Implementation.Services.Inputs;
using Sources.Game.Implementation.Services.Lifecycles;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Lifecycles;
using UniCtor.Installers;
using UniCtor.Services;

namespace Sources.MonoInstallers
{
    public class GameplayMonoInstaller : MonoInstaller
    {
        public override void OnConfigure(IServiceCollection services)
        {
            UpdateService updateService = new UpdateService();
            FixedUpdateService fixedUpdateService = new FixedUpdateService();
            
            services
                .RegisterAsSingleton<IUpdateService>(updateService)
                .RegisterAsSingleton<IUpdateHandler>(updateService)
                .RegisterAsSingleton< IFixedUpdateHandler>(fixedUpdateService)
                .RegisterAsSingleton<IFixedUpdateService>(fixedUpdateService)
                .RegisterAsSingleton<IInputService,PcInputService>()
               ;
        }
    }
}