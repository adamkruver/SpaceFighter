using Sources.Extensions.IServiceCollections;
using Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Factories;
using Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Views;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Factories;
using Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Factories;
using Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Services;
using Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Views;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Factories;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Services;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Views;
using Sources.Game.Implementation.Controllers;
using Sources.Game.Implementation.Services.Inputs;
using Sources.Game.Implementation.Services.Lifecycles;
using Sources.Game.Implementation.Services.Spaceships;
using Sources.Game.Implementation.Services.TargetFollowers;
using Sources.Game.Interfaces.Infrastructure.Handlers;
using Sources.Game.Interfaces.Services.Inputs;
using Sources.Game.Interfaces.Services.Lifecycles;
using Sources.Game.Interfaces.Services.Spaceship;
using Sources.Game.Interfaces.Services.TargetFollowers;
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
                .RegisterAsSingleton<IInputService, PcInputService>()
                .RegisterAsSingleton<ICameraFollower, ICameraLateUpdateHandler, TargetFollowerService>(
                    new TargetFollowerService(_mainCamera)
                )
                .RegisterAsSingleton<ISpaceshipService, SpaceshipService>()
                .RegisterAsScoped<ITorqueService, SlerpTorqueService>()
                .RegisterAsScoped<IPhysicsMovementViewFactory<PhysicsMovementView>,
                    PhysicsMovementViewFactory<PhysicsMovementView>>()
                .RegisterAsScoped<IPhysicsTorqueViewFactory<PhysicsTorqueView>,
                    PhysicsTorqueViewFactory<PhysicsTorqueView>>();

        }
    }
}