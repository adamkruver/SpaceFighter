using Sources.BoundedContexts.PhysicsMovement.Implementation.Factories;
using Sources.BoundedContexts.PhysicsMovement.Implementation.Views;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Factories;
using Sources.BoundedContexts.PhysicsTorque.Implementation.Factories;
using Sources.BoundedContexts.PhysicsTorque.Implementation.Services;
using Sources.BoundedContexts.PhysicsTorque.Implementation.Views;
using Sources.BoundedContexts.PhysicsTorque.Interfaces.Factories;
using Sources.BoundedContexts.PhysicsTorque.Interfaces.Services;
using Sources.BoundedContexts.Weapons.Implementation.Factories;
using Sources.Extensions.IServiceCollections;
using Sources.Implementation.Services.Inputs;
using Sources.Implementation.Services.Lifecycles;
using Sources.Implementation.Services.Spaceships;
using Sources.Implementation.Services.TargetFollowers;
using Sources.Interfaces.Infrastructure.Handlers;
using Sources.Interfaces.Services.Inputs;
using Sources.Interfaces.Services.Lifecycles;
using Sources.Interfaces.Services.Spaceship;
using Sources.Interfaces.Services.TargetFollowers;
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
                    new TargetFollowerService(_mainCamera)
                )
                .RegisterAsSingleton<ISpaceshipService, SpaceshipService>()
                .RegisterAsScoped<ITorqueService, SlerpTorqueService>()
                .RegisterAsScoped<IPhysicsMovementViewFactory<PhysicsMovementView>,
                    PhysicsMovementViewFactory<PhysicsMovementView>>()
                .RegisterAsScoped<IPhysicsTorqueViewFactory<PhysicsTorqueView>,
                    PhysicsTorqueViewFactory<PhysicsTorqueView>>()
                .RegisterAsScoped<IWeaponViewFactory,WeaponViewFactory>()
                ;
        }
    }
}