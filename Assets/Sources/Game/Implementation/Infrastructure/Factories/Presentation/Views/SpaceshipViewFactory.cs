using System;
using Sources.Game.BoundedContexts.PhysicsMovement.Implementation.Views;
using Sources.Game.BoundedContexts.PhysicsMovement.Interfaces.Factories;
using Sources.Game.BoundedContexts.PhysicsTorque.Implementation.Views;
using Sources.Game.BoundedContexts.PhysicsTorque.Interfaces.Factories;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Infrastructure.Factories.Controllers;
using Sources.Game.Implementation.Presentation.Views;
using UniCtor.Builders;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;
using UnityEngine;

namespace Sources.Game.Implementation.Infrastructure.Factories.Presentation.Views
{
    public class SpaceshipViewFactory
    {
        private readonly SpaceshipPresenterFactory _spaceshipPresenterFactory;
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IPhysicsMovementViewFactory<PhysicsMovementView> _physicsMovementViewFactory;
        private readonly IPhysicsTorqueViewFactory<PhysicsTorqueView> _physicsTorqueViewFactory;

        public SpaceshipViewFactory(
            SpaceshipPresenterFactory spaceshipPresenterFactory,
            IDependencyResolver dependencyResolver,
            IPhysicsMovementViewFactory<PhysicsMovementView> physicsMovementViewFactory,
            IPhysicsTorqueViewFactory<PhysicsTorqueView> physicsTorqueViewFactory
        )
        {
            _spaceshipPresenterFactory = spaceshipPresenterFactory ??
                                         throw new ArgumentNullException(nameof(spaceshipPresenterFactory));
            _dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
            _physicsMovementViewFactory = physicsMovementViewFactory ??
                                          throw new ArgumentNullException(nameof(physicsMovementViewFactory));
            _physicsTorqueViewFactory = physicsTorqueViewFactory ?? throw new ArgumentNullException(nameof(physicsTorqueViewFactory));
        }

        public SpaceshipView Create(Spaceship spaceship)
        {
            SpaceshipView prefab = Resources.Load<SpaceshipView>("Views/SpaceshipView");
            SpaceshipView view = _dependencyResolver.InstantiateComponentFromPrefab(prefab);
            var presenter = _spaceshipPresenterFactory.Create(spaceship, view);
            view.Construct(presenter);

            _physicsMovementViewFactory.Create(spaceship.Movement, view.PhysicsMovementView);
            _physicsTorqueViewFactory.Create(spaceship.Torque, view.PhysicsTorqueView);

            return view;
        }
    }
}