using System;
using JetBrains.Annotations;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Infrastructure.Factories.Controllers;
using Sources.Game.Implementation.Presentation.Views;
using UniCtor.Builders;
using UniCtor.Sources.Di.Extensions.IDependencyResolvers;
using Unity.VisualScripting;
using UnityEngine;


namespace Sources.Game.Implementation.Infrastructure.Factories.Presentation.Views
{
    public class SpaceshipViewFactory
    {
        private readonly SpaceshipPresenterFactory _spaceshipPresenterFactory;
        private readonly IDependencyResolver _dependencyResolver;

        public SpaceshipViewFactory(SpaceshipPresenterFactory spaceshipPresenterFactory, IDependencyResolver dependencyResolver)
        {
            _spaceshipPresenterFactory = spaceshipPresenterFactory ?? throw new ArgumentNullException(nameof(spaceshipPresenterFactory));
            _dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
        }

        public SpaceshipView Create(Spaceship spaceship)
        {
            SpaceshipView prefab = Resources.Load<SpaceshipView>("Views/SpaceshipView");
            var view = _dependencyResolver.InstantiateComponentFromPrefab(prefab);
            var presenter = _spaceshipPresenterFactory.Create(spaceship, view, view.PhysicsMovementSystem);
            view.Construct(presenter);

            return view;
        } 
    }
}