using System;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Infrastructure.Factories.Controllers;
using Sources.Game.Implementation.Presentation.Views;
using UnityEngine;
using Zenject;

namespace Sources.Game.Implementation.Infrastructure.Factories.Presentation.Views
{
    public class SpaceshipViewFactory
    {
        private readonly SpaceshipPresenterFactory _spaceshipPresenterFactory;
        private readonly DiContainer _diContainer;

        public SpaceshipViewFactory(SpaceshipPresenterFactory spaceshipPresenterFactory, DiContainer diContainer)
        {
            _spaceshipPresenterFactory = spaceshipPresenterFactory ?? throw new ArgumentNullException(nameof(spaceshipPresenterFactory));
            _diContainer = diContainer ?? throw new ArgumentNullException(nameof(diContainer));
        }

        public SpaceshipView Create(Spaceship spaceship)
        {
            var prefab = Resources.Load<SpaceshipView>("Views/SpaceshipView");
                
            var view = _diContainer.InstantiatePrefabForComponent<SpaceshipView>(prefab);
            var presenter = _spaceshipPresenterFactory.Create(spaceship, view);
            view.Construct(presenter);

            return view;
        } 
    }
}