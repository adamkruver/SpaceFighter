using System;
using Sources.BoundedContexts.PhysicsMovement.Implementation.Views;
using Sources.BoundedContexts.PhysicsMovement.Interfaces.Factories;
using Sources.BoundedContexts.PhysicsTorque.Implementation.Views;
using Sources.BoundedContexts.PhysicsTorque.Interfaces.Factories;
using Sources.BoundedContexts.Weapons.Implementation.Factories;
using Sources.BoundedContexts.Weapons.Implementation.Presentation.Weapons;
using Sources.Implementation.Domain;
using Sources.Implementation.Infrastructure.Factories.Controllers;
using Sources.Implementation.Presentation.Views;
using UniCtor.Builders;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;
using UnityEngine;

namespace Sources.Implementation.Infrastructure.Factories.Presentation.Views
{
    public class SpaceshipViewFactory
    {
        private readonly SpaceshipPresenterFactory _spaceshipPresenterFactory;
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IPhysicsMovementViewFactory<PhysicsMovementView> _physicsMovementViewFactory;
        private readonly IPhysicsTorqueViewFactory<PhysicsTorqueView> _physicsTorqueViewFactory;
        private readonly IWeaponViewFactory _weaponViewFactory;

        public SpaceshipViewFactory(
            SpaceshipPresenterFactory spaceshipPresenterFactory,
            IDependencyResolver dependencyResolver,
            IPhysicsMovementViewFactory<PhysicsMovementView> physicsMovementViewFactory,
            IPhysicsTorqueViewFactory<PhysicsTorqueView> physicsTorqueViewFactory,
            IWeaponViewFactory weaponViewFactory
            )
        {
            _spaceshipPresenterFactory = spaceshipPresenterFactory ??
                                         throw new ArgumentNullException(nameof(spaceshipPresenterFactory));
            _dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
            _physicsMovementViewFactory = physicsMovementViewFactory ??
                                          throw new ArgumentNullException(nameof(physicsMovementViewFactory));
            _physicsTorqueViewFactory = physicsTorqueViewFactory ?? throw new ArgumentNullException(nameof(physicsTorqueViewFactory));
            _weaponViewFactory = weaponViewFactory ?? throw new ArgumentNullException(nameof(weaponViewFactory));
        }

        public SpaceshipView Create(Spaceship spaceship)
        {
            SpaceshipView prefab = Resources.Load<SpaceshipView>("Views/SpaceshipView");
            SpaceshipView view = _dependencyResolver.InstantiateComponentFromPrefab(prefab);
            var presenter = _spaceshipPresenterFactory.Create(spaceship, view);
            view.Construct(presenter);

            _physicsMovementViewFactory.Create(spaceship.Movement, view.PhysicsMovementView);
            _physicsTorqueViewFactory.Create(spaceship.Torque, view.PhysicsTorqueView);
            var s = _weaponViewFactory.Create(spaceship.Movement, spaceship.Torque, view.gameObject.GetComponentInChildren<WeaponView>());
            
            return view;
        }
    }
}