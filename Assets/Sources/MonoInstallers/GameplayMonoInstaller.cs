using Sources.BoundedContexts.Assets.Implementation;
using Sources.BoundedContexts.Assets.Interfaces;
using Sources.BoundedContexts.Inputs.Implementation.Services;
using Sources.BoundedContexts.Inputs.Interfaces.Services;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Factories;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Views;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Domain;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Factories;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Services;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Services;
using Sources.BoundedContexts.Weapons.Implementation.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Factories;
using Sources.Common.StateMachines.Implementation.Services;
using Sources.Common.StateMachines.Interfaces.Handlers;
using Sources.Common.StateMachines.Interfaces.Services;
using Sources.Extensions.IServiceCollections;
using Sources.Implementation.Services.Spaceships;
using Sources.Implementation.Services.TargetFollowers;
using Sources.Interfaces.Services.Inputs;
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
				.RegisterAsSingleton<ICameraFollower, ICameraLateUpdateHandler, TargetFollowerService>(new TargetFollowerService(_mainCamera))
				.RegisterAsScoped<ITorqueService, SlerpTorqueService>()
				.RegisterAsScoped<IPhysicsMovementViewFactory<PhysicsMovementView>,
					PhysicsMovementViewFactory<PhysicsMovementView>>()
				.RegisterAsScoped<IPhysicsTorqueViewFactory<PhysicsTorqueView>,
					SpaceshipPhysicsTorqueViewFactory<PhysicsTorqueView>>()
				.RegisterAsScoped<IWeaponViewFactory, WeaponViewFactory>()
				.RegisterAsScoped<IWeaponShootService, WeaponShootService>()
				
				.RegisterAsSingleton<IAssetService>
					(
						serviceProvider =>
							new CompositeAssetService(serviceProvider.GetService<AssetService<PlayerAssetProvider>>()
							)
					)

				.RegisterAsSingleton<AssetService<PlayerAssetProvider>>()
				
				.RegisterAsSingleton<PlayerAssetProvider>(serviceProvider =>
				{
					return serviceProvider.GetService<AssetService<PlayerAssetProvider>>().Provider;
				});
		}
	}
}
//TODO зОчем?
//.RegisterAsSingleton<IPhysicsMovement, PhysicsMovement>()
//.RegisterAsSingleton<ISpaceshipService, SpaceshipService>()