using System;
using Sources.Implementation.Controllers;
using Sources.Implementation.Domain;
using Sources.Implementation.Infrastructure.Factories.Controllers;
using Sources.Implementation.Presentation.Views;
using UniCtor.Builders;
using UnityEngine;

namespace Sources.Implementation.Infrastructure.Factories.Presentation.Views
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
            
			EmptyTargetPresenter presenter = _spaceshipCameraPresenterFactory.Create(emptyTarget);
			emptyTargetView.Construct(presenter);

			return emptyTargetView;
		} 
	}
}