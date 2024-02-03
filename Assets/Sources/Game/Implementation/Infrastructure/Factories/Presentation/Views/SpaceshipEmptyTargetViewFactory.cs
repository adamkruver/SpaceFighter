using System;
using Sources.Game.Implementation.Controllers;
using Sources.Game.Implementation.Domain;
using Sources.Game.Implementation.Infrastructure.Factories.Controllers;
using Sources.Game.Implementation.Presentation.Views;
using UniCtor.Builders;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Game.Implementation.Infrastructure.Factories.Presentation.Views
{
	public class SpaceshipEmptyTargetViewFactory
	{
		private readonly SpaceshipCameraPresenterFactory _spaceshipCameraPresenterFactory;
		private readonly IDependencyResolver _dependencyResolver;

		public SpaceshipEmptyTargetViewFactory(SpaceshipCameraPresenterFactory spaceshipCameraPresenterFactory, IDependencyResolver dependencyResolver)
		{
			_spaceshipCameraPresenterFactory = spaceshipCameraPresenterFactory ?? throw new ArgumentNullException(nameof(spaceshipCameraPresenterFactory));
			_dependencyResolver = dependencyResolver ?? throw new ArgumentNullException(nameof(dependencyResolver));
		}

		public EmptyTargetView Create(EmptyTarget emptyTarget, Spaceship spaceship, SpaceshipView spaceshipView)
		{
			GameObject gameObject = new GameObject();
			gameObject.transform.SetParent(spaceshipView.transform);
			
			EmptyTargetView emptyTargetView = gameObject.AddComponent<EmptyTargetView>();
			_dependencyResolver.Resolve(emptyTargetView.gameObject);
            
			SpaceshipCameraPresenter presenter = _spaceshipCameraPresenterFactory.Create(emptyTarget, spaceship);
			emptyTargetView.Construct(presenter);

			return emptyTargetView;
		} 
	}
}