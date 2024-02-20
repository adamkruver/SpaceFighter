using System;
using Sources.BoundedContexts.Assets.Implementation;
using Sources.BoundedContexts.MoveWithPhysics.Implementation.Views;
using Sources.BoundedContexts.MoveWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.Spaceships.Implementation.Domain.Models;
using Sources.BoundedContexts.Spaceships.Implementation.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Implementation.Views;
using Sources.BoundedContexts.TorqueWithPhysics.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Interfaces.Factories;
using UniCtor.Builders;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;

namespace Sources.BoundedContexts.Spaceships.Implementation.Factories
{
	public class SpaceshipViewFactory
	{
		private readonly SpaceshipPresenterFactory _spaceshipPresenterFactory;
		private readonly IDependencyResolver _dependencyResolver;
		private readonly IPhysicsMovementViewFactory<PhysicsMovementView> _physicsMovementViewFactory;
		private readonly IPhysicsTorqueViewFactory<PhysicsTorqueView> _physicsTorqueViewFactory;
		private readonly IWeaponViewFactory _weaponViewFactory;
		private readonly AssetService<PlayerAssetProvider> _service;
		private SpaceshipView _spaceshipViewPrefab;

		public SpaceshipViewFactory(SpaceshipPresenterFactory spaceshipPresenterFactory,
			IDependencyResolver dependencyResolver,
			IPhysicsMovementViewFactory<PhysicsMovementView> physicsMovementViewFactory,
			IPhysicsTorqueViewFactory<PhysicsTorqueView> physicsTorqueViewFactory,
			IWeaponViewFactory weaponViewFactory,
			AssetService<PlayerAssetProvider> service
			)
		{
			_spaceshipPresenterFactory = spaceshipPresenterFactory ??
			                             throw new ArgumentNullException(nameof(spaceshipPresenterFactory));
			_dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
			_physicsMovementViewFactory = physicsMovementViewFactory ??
			                              throw new ArgumentNullException(nameof(physicsMovementViewFactory));
			_physicsTorqueViewFactory = physicsTorqueViewFactory ?? throw new ArgumentNullException(nameof(physicsTorqueViewFactory));
			_weaponViewFactory = weaponViewFactory ?? throw new ArgumentNullException(nameof(weaponViewFactory));
			_service = service ?? throw new ArgumentNullException(nameof(service));
		}
		
		public SpaceshipView Create(Spaceship spaceship)
		{
			SpaceshipView view = _dependencyResolver.InstantiateComponentFromPrefab(_service.Provider.SpaceshipView);
			var presenter = _spaceshipPresenterFactory.Create(spaceship, view);
			view.Construct(presenter);

			_physicsMovementViewFactory.Create(spaceship.Movement, view.PhysicsMovementView);
			_physicsTorqueViewFactory.Create(spaceship.Torque, view.PhysicsTorqueView);
			_weaponViewFactory.Create(spaceship.Weapon, view.WeaponView);

			return view;
		}
		
	}
}