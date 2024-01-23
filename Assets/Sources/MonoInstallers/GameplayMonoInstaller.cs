using Sources.Game.Implementation.Infrastructure.Factories.Controllers;
using Sources.Game.Implementation.Infrastructure.Factories.Presentation.Views;
using Sources.Game.Implementation.Services.Inputs;
using Sources.Game.Implementation.Services.Lifecycles;
using Sources.Game.Implementation.Services.Spaceships;
using Sources.Game.Interfaces.Services.Inputs;
using Zenject;

namespace Sources.MonoInstallers
{
    public class GameplayMonoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.Bind<IInputService>().To<PcInputService>().AsSingle();
            Container.Bind<SpaceshipViewFactory>().AsSingle();
            Container.Bind<SpaceshipPresenterFactory>().AsSingle();
            Container.Bind<SpaceshipMovementService>().AsSingle();
        }
    }
}