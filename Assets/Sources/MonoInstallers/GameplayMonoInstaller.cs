using Sources.BoundedContexts.Assets.Implementation;
using Sources.BoundedContexts.Assets.Interfaces;
using Sources.BoundedContexts.Inputs.Implementation.Services;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Factories;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Views;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.Overlaps.Implementation.Services;
using Sources.BoundedContexts.Overlaps.Interfaces.Services;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Factories;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Services;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
using Sources.BoundedContexts.Weapons.Implementation.Domain.Services;
using Sources.BoundedContexts.Weapons.Implementation.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Services;
using Sources.Common.StateMachines.Implementation.Services;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.Services;
using Sources.Extensions.IServiceCollections;
using Sources.Implementation;
using Sources.Interfaces.Services;
using UniCtor.Installers;
using UniCtor.Services;
using UnityEngine;

namespace Sources.MonoInstallers
{
    public class GameplayMonoInstaller : MonoInstaller
    {
        [SerializeField] private Transform _mainCamera;

        public override void OnConfigure(IServiceCollection services)
        {
            services
                .RegisterAsSingleton<IUpdateService, IUpdateHandler, UpdateService>()
                .RegisterAsSingleton<IFixedUpdateService, IFixedUpdateHandler, FixedUpdateService>()
                .RegisterAsSingleton<ILateUpdateService, ILateUpdateHandler, LateUpdateService>()
                .RegisterAsSingleton<IInputService, PcInputService>()
                .RegisterAsSingleton<ICameraFollower, ICameraLateUpdateHandler, TargetFollowerService>(
                    new TargetFollowerService(_mainCamera))
                .RegisterAsScoped<ITorqueService, SlerpTorqueService>()
                .RegisterAsScoped<IPhysicsMovementViewFactory<PhysicsMovementView>,
                    PhysicsMovementViewFactory<PhysicsMovementView>>()
                .RegisterAsScoped<IPhysicsTorqueViewFactory<PhysicsTorqueView>,
                    SpaceshipPhysicsTorqueViewFactory<PhysicsTorqueView>>()
                .RegisterAsScoped<IWeaponViewFactory, WeaponViewFactory>()
                .RegisterAsScoped<IWeaponShootService, WeaponShootService>()
                .RegisterAsScoped<IAssetService>
                (
                    serviceProvider =>
                        new CompositeAssetService
                        (
                            serviceProvider.GetService<AssetService<PlayerAssetProvider>>(),
                            serviceProvider.GetService<AssetService<BulletAssetProvider>>(),
                            serviceProvider.GetService<AssetService<UiAssetProvider>>()
                        )
                )
                .RegisterAsScoped<AssetService<PlayerAssetProvider>>()
                .RegisterAsScoped<AssetService<BulletAssetProvider>>()
                .RegisterAsScoped(serviceProvider =>
                    serviceProvider.GetService<AssetService<PlayerAssetProvider>>().Provider)
                .RegisterAsScoped(serviceProvider =>
                    serviceProvider.GetService<AssetService<BulletAssetProvider>>().Provider)
                .RegisterAsScoped<AssetService<UiAssetProvider>>()
                .RegisterAsScoped(provider => provider.GetService<AssetService<UiAssetProvider>>().Provider)
                .RegisterAsScoped<IOverlapService, OverlapService>()
                
                
                ;
        }
    }
}